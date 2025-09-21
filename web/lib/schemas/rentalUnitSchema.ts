import { z } from "zod";

export const rentalUnitSchema = z.object({
  address: z.object({
    street: z.string(),
    houseNumber: z.string(),
    city: z.string(),
  }),
  type: z.enum(["room", "apartment", "house"]),
  numberOfRooms: z.number(),
  sizeSquareMeters: z.number(),
  imageUrls: z.array(z.string()),
});

export type RentalUnitData = z.infer<typeof rentalUnitSchema>;
