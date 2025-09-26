"use server";

import { postAuthenticated } from "../api/server";
import { ListingData, listingSchema } from "../schemas/listingSchema";

export async function createListing(data: ListingData) {
  const parsed = listingSchema.parse(data);
  const response = await postAuthenticated("my/listings", parsed);

  if (!response.ok) {
    //Do Something
  }
}
