import { Image } from "./Common";

export interface LandlordProfile {
  name: string;
  image: Image;
  phone?: string;
  email?: string;
}
