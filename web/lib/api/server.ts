import "server-only";

import { cookies } from "next/headers";

export async function getAuthenticated(endpoint: string): Promise<Response> {
  const url = `${process.env.BACKEND_URL}/${endpoint}`;

  const accessToken = await getAccessToken();

  const response = await fetch(url, {
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${accessToken}`,
    },
  });

  return response;
}

export async function postAuthenticated(
  endpoint: string,
  data: any
): Promise<Response> {
  const url = `${process.env.BACKEND_URL}/${endpoint}`;

  const accessToken = await getAccessToken();

  const response = await fetch(url, {
    method: "POST",
    body: JSON.stringify(data),
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${accessToken}`,
    },
  });

  return response;
}

export async function getAccessToken() {
  return (await cookies()).get("__Host-accessToken");
}
