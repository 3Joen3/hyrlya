const backendUrl = "https://localhost:7090";

export async function post<T>(
  endpoint: string,
  data: any,
  expectResponse?: boolean
) {
  const url = `${backendUrl}/${endpoint}`;

  const response = await fetch(url, {
    method: "POST",
    body: JSON.stringify(data),
    headers: { "Content-Type": "application/json" },
  });

  if (!response.ok) {
    const errorMessage = await response.text();
    throw new Error(
      `[post] ${url} failed with status code: ${response.status} with message: ${errorMessage}`
    );
  }

  if (expectResponse) return (await response.json()) as T;

  return;
}
