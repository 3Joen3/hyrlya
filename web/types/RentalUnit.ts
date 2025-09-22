import { Image } from "./Common";
export interface RentalUnitSummary {
  id: string;
  address: Address;
}

export interface RentalUnitDetails {
  address: Address;
  type: "room" | "apartment" | "house";
  numberOfRooms: number;
  sizeSquareMeters: number;
  images: Image[];
}

export interface Address {
  street: string;
  houseNumber: string;
  city: string;
}
