import { z } from "zod";

export const rentalUnitSchema = z.object({
  street: z.string(),
  houseNumber: z.string(),
  city: z.string(),
  type: z.enum(["room", "apartment", "house"]),
  rooms: z.number(),
  sizeSquareMeters: z.number(),
  imageUrls: z.array(z.string()),
});

export type RentalUnitData = z.infer<typeof rentalUnitSchema>;
