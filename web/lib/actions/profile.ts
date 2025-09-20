"use server";

import { postAuthenticated } from "@/lib/api/server";
import { ProfileData, profileSchema } from "@/lib/schemas/profileSchema";
import { redirect } from "next/navigation";

export async function createLandlord(data: ProfileData) {
  const parsed = profileSchema.parse(data);

  const response = await postAuthenticated("my/landlord", parsed);

  if (!response.ok) {
    //Do Something
  }

  redirect("/landlord");
}
