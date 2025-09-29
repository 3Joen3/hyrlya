import { z } from "zod";

export const listingSchema = z.object({
  rentalUnitId: z.string(),
  price: z.number(),
  chargeInterval: z.enum(["daily", "weekly", "monthly"]),
  landlordNote: z.string(),
});

export type ListingData = z.infer<typeof listingSchema>;
