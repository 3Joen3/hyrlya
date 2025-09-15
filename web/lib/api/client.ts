export async function postNoResponse(endpoint: string, data: any) {
  const url = `${process.env.BACKEND_URL}/${endpoint}`;

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
}

export async function post<T>(endpoint: string, data: any) {
  const url = `${process.env.BACKEND_URL}/${endpoint}`;

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

  return (await response.json()) as T;
}
