import { Image } from "./Common";

export interface LandlordDetails {
  profile: LandlordProfile;
}

export interface LandlordProfile {
  name: string;
  image: Image;
  phone: string;
  email: string;
}
