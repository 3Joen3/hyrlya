import ListingPageSection from "./ListingPageSection";
import ListingPageIconRow from "./ListingPageIconRow";

import { ArrowsPointingOutIcon, BanknotesIcon, MapPinIcon } from "@heroicons/react/24/outline";
import { TranslateRentalPriceChargeInterval } from "@/lib/utils";
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

  return (
    <ListingPageSection heading="Info">
      <ListingPageIconRow icon={MapPinIcon} text={addressText} />
      <ListingPageIconRow icon={BanknotesIcon} text={priceText} />
      <ListingPageIconRow icon={ArrowsPointingOutIcon} text={sizeText} />
    </ListingPageSection>
  );
}
