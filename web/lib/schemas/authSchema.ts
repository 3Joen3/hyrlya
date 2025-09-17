import { z } from "zod";

export const authSchema = z.object({
  email: z.email(),
  password: z.string(),
});

export type AuthData = z.infer<typeof authSchema>;