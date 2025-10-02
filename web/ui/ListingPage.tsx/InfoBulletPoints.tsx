import ListingPageSection from "./ListingPageSection";
import ListingPageIconRow from "./ListingPageIconRow";

import {
  ArrowsPointingOutIcon,
  BanknotesIcon,
  MapPinIcon,
  HomeModernIcon,
} from "@heroicons/react/24/outline";
import { TranslateRentalPriceChargeInterval, TranslateRentalUnitType } from "@/lib/utils";
import { RentalPrice } from "@/types/Listing";
import { RentalUnitDetails } from "@/types/RentalUnit";

interface Props {
  rentalUnit: RentalUnitDetails;
  rentalPrice: RentalPrice;
}

export default function InfoBulletPoints({ rentalUnit, rentalPrice }: Props) {
  const address = rentalUnit.address;

  const addressText = `${address.street} ${address.houseNumber}, ${address.city}`;
  const priceText = `${rentalPrice.amount} kr/${TranslateRentalPriceChargeInterval(
    rentalPrice.chargeInterval
  )}`;
  const sizeText = `${rentalUnit.numberOfRooms} rum, ${rentalUnit.sizeSquareMeters} m²`;
  const typeText = TranslateRentalUnitType(rentalUnit.type);

  return (
    <ListingPageSection heading="Info">
      <ListingPageIconRow icon={HomeModernIcon} text={typeText} />
      <ListingPageIconRow icon={ArrowsPointingOutIcon} text={sizeText} />
      <ListingPageIconRow icon={MapPinIcon} text={addressText} />
      <ListingPageIconRow icon={BanknotesIcon} text={priceText} />
    </ListingPageSection>
  );
}
