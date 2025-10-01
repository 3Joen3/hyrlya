"use server";

import { postAuthenticated, putAuthenticated } from "@/lib/api/server";
import { ProfileData, profileSchema } from "@/lib/schemas/profileSchema";
import { redirect } from "next/navigation";

export async function updateLandlord(data: ProfileData) {
  const parsed = profileSchema.parse(data);
  const response = await putAuthenticated("my/landlord", parsed);
  if (!response.ok) {
    //DO SOmething
  }
}

export async function createLandlord(data: ProfileData) {
  const parsed = profileSchema.parse(data);

  const response = await postAuthenticated("my/landlord", parsed);

  if (!response.ok) {
    //Do Something
  }

  redirect("/landlord");
}
