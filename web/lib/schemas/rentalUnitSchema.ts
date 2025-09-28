import { z } from "zod";

export const rentalUnitSchema = z.object({
  address: z.object({
    street: z.string().min(1, "Gatuadress är obligatoriskt"),
    houseNumber: z.string().min(1, "Husnummer är obligatoriskt"),
    city: z.string().min(1, "Stad är obligatoriskt"),
  }),
  type: z.enum(["room", "apartment", "house"]),
  numberOfRooms: z
    .number("Antal rum måste vara ett nummer")
    .positive("Antal rum måste vara över noll"),
  sizeSquareMeters: z
    .number("Storlek måste vara ett nummer")
    .positive("Antal rum måste vara över noll"),
  description: z.string().min(1, "Beskrivning är obligatoriskt"),
  imageUrls: z.array(z.url()).min(1, "Minst en bild krävs"),
});

export type RentalUnitData = z.infer<typeof rentalUnitSchema>;
