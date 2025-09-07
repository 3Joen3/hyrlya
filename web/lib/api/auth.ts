import { RegisterData } from "../schemas/registerSchema";
import { post } from "./utils";

export async function register(request: RegisterData) {
  const response = await post<void>("register", request);
}
