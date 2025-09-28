import { Image } from "./Common";

export interface RentalUnitSummary {
  id: string;
  type: "room" | "apartment" | "house";
  address: Address;
}

export interface RentalUnitDetails {
  id: string;
  type: "room" | "apartment" | "house";
  address: Address;
  numberOfRooms: number;
  sizeSquareMeters: number;
  images: Image[];
  description: string;
}

export interface Address {
  street: string;
  houseNumber: string;
  city: string;
}
