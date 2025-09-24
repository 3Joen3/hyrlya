import { z } from "zod";

export const listingSchema = z.object({
  rentalUnitId: z.string(),
  rentalType: z.enum(["primaryResidence", "vacationHome"]),
});

export type ListingData = z.infer<typeof listingSchema>;
