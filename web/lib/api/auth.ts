import { RegisterData } from "../schemas/registerSchema";
import { postNoResponse, post } from "./utils";
import { LoginData } from "../schemas/loginSchema";
import { LoginResponse } from "@/types/LoginResponse";

export async function register(request: RegisterData) {
  await postNoResponse("register", request);
}

export async function login(request: LoginData) {
  const response = await post<LoginResponse>("login", request);

  if (!response.accessToken) {
    throw new Error(
      "Login request was successful but token wasn't present in response."
    );
  }

  localStorage.setItem("accessToken", response.accessToken);
}
