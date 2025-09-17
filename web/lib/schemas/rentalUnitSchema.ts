import { z } from "zod";

export const rentalUnitSchema = z.object({
  street: z.string(),
  houseNumber: z.string(),
  city: z.string(),
  type: z.number().int().min(1).max(3),
  rooms: z.number(),
  sizeSquareMeters: z.number(),
  imageUrls: z.array(z.string()),
});

export type RentalUnitData = z.infer<typeof rentalUnitSchema>;
