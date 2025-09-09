"use server";

import { RegisterData } from "@/lib/schemas/registerSchema";
import { LoginData } from "@/lib/schemas/loginSchema";
import { post, postNoResponse } from "@/lib/utils/api";
import { LoginResponse } from "@/types/LoginResponse";
import { cookies } from "next/headers";
import type { ReadonlyRequestCookies } from "next/dist/server/web/spec-extension/adapters/request-cookies";

export async function register(request: RegisterData) {
  await postNoResponse("register", request);
}

export async function login(data: LoginData) {
  const response = await post<LoginResponse>("login", data);

  const cookieStore = await cookies();

  const bufferedExpiry = response.expiresIn - 60;

  setAuthCookie(
    cookieStore,
    "accessToken",
    response.accessToken,
    bufferedExpiry
  );
  //SET A REAL EXPIRY DATE, SHOULD NOT BE SAME AS AT
  setAuthCookie(cookieStore, "refresh", response.refreshToken, bufferedExpiry);
}

function setAuthCookie(
  cookieStore: ReadonlyRequestCookies,
  name: string,
  value: string,
  maxAge: number
) {
  cookieStore.set(`__Host-${name}`, value, {
    httpOnly: true,
    secure: true,
    sameSite: "lax",
    path: "/",
    maxAge,
  });
}
