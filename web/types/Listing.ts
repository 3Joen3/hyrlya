import { Image } from "./Common";
import { Address } from "./RentalUnit";

export interface ListingSummary {
  id: string;
  image: Image;
  address: Address;
  rentalPrice: RentalPrice;
}

export interface ListingDetails {
  id: string;
}

export interface RentalPrice {
  amount: number;
  chargeInterval: string;
}
