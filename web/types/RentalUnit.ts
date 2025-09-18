import { Image } from "./Common";
export interface RentalUnitSummary {
  id: string;
  address: Address;
}

export interface RentalUnitDetails {
  images: Image;
}

export interface Address {
  street: string;
  houseNumber: string;
  city: string;
}
