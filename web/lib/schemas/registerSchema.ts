import { z } from "zod";

export const registerSchema = z.object({
  email: z.email({ message: "Ogiltig e-postadress" }),
  password: z
    .string()
    .min(6, "Lösenordet måste vara minst 6 tecken")
    .regex(/[a-z]/, "Lösenordet måste innehålla minst en liten bokstav")
    .regex(/[A-Z]/, "Lösenordet måste innehålla minst en stor bokstav")
    .regex(/[0-9]/, "Lösenordet måste innehålla minst en siffra")
    .regex(/[^a-zA-Z0-9]/, "Lösenordet måste innehålla minst ett specialtecken")
});

export type RegisterData = z.infer<typeof registerSchema>;
