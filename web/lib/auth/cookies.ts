import "server-only";

import { cookies } from "next/headers";

export async function getAccessToken() {
  return (await cookies()).get("__Host-accessToken");
}
