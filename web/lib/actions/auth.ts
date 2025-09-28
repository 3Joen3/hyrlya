"use server";

import { LoginData } from "../schemas/loginSchema";
import { postNoResponse, post } from "@/lib/api/client";
import { LoginResponse } from "@/types/LoginResponse";
import { cookies } from "next/headers";
import { RegisterData } from "../schemas/registerSchema";

export async function register(request: RegisterData) {
  await postNoResponse("register", request);
}

export async function login(data: LoginData) {
  const response = await post<LoginResponse>("login", data);

  const bufferedExpiry = response.expiresIn - 60;

  await setAuthCookie("accessToken", response.accessToken, bufferedExpiry);
  await setAuthCookie("refresh", response.refreshToken, 604800);
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
