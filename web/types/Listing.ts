import { Image } from "./Common";
import { LandlordProfile } from "./Landlord";
import { Address, RentalUnitDetails } from "./RentalUnit";

export interface ListingSummary {
  id: string;
  image: Image;
  address: Address;
  rentalPrice: RentalPrice;
}

export interface ListingDetails {
  landlord: LandlordProfile;
  rentalUnit: RentalUnitDetails;
  rentalPrice: RentalPrice;
}

export interface RentalPrice {
  amount: number;
  chargeInterval: "daily" | "weekly" | "monthly";
}
