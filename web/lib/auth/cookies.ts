import "server-only";

import { getCookie } from "../utils/cookies";
import { cookies } from "next/headers";

export async function getAccessToken() {
  return getCookie("__Host-accessToken");
}

export async function setAuthCookie(
  name: string,
  value: string,
  maxAge: number
) {
  const cookieStore = await cookies();
  cookieStore.set(`__Host-${name}`, value, {
    httpOnly: true,
    secure: true,
    sameSite: "lax",
    path: "/",
    maxAge,
  });
}
