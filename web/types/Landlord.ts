import { Image } from "./Common";

export interface Landlord {
  id: string;
  profile: LandlordProfile;
}

export interface LandlordProfile {
  name: string;
  image: Image;
  phone?: string;
  email?: string;
}
