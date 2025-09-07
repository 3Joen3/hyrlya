import { z } from "zod";

export const registerSchema = z.object({
  email: z.email(),
  password: z.string(),
});

export type RegisterData = z.infer<typeof registerSchema>;
