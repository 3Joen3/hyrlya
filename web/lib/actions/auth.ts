"use server";

import { RegisterData } from "@/lib/schemas/registerSchema";
import { LoginData } from "@/lib/schemas/loginSchema";
import { post, postNoResponse } from "@/lib/api/client";
import { LoginResponse } from "@/types/LoginResponse";
import { cookies } from "next/headers";

export async function register(request: RegisterData) {
  await postNoResponse("register", request);
}

export async function login(data: LoginData) {
  const response = await post<LoginResponse>("login", data);

  const bufferedExpiry = response.expiresIn - 60;

  await setAuthCookie("accessToken", response.accessToken, bufferedExpiry);

  //SET A REAL EXPIRY DATE, SHOULD NOT BE SAME AS AT
  await setAuthCookie("refresh", response.refreshToken, bufferedExpiry);
}

async function setAuthCookie(name: string, value: string, maxAge: number) {
  const cookieStore = await cookies();
  cookieStore.set(`__Host-${name}`, value, {
    httpOnly: true,
    secure: true,
    sameSite: "lax",
    path: "/",
    maxAge,
  });
}
