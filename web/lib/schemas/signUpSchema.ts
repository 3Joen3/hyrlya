import { z } from "zod";

export const signUpSchema = z.object({
  firstName: z.string(),
  lastName: z.string(),
  email: z.email(),
  password: z.string(),
});

export type SignUpData = z.infer<typeof signUpSchema>;
