import { z } from "zod";

export const profileSchema = z.object({
  name: z.string(),
  profileImageUrl: z.string(),
  phoneNumber: z.string(),
  emailAddress: z.email(),
});

export type ProfileData = z.infer<typeof profileSchema>;
