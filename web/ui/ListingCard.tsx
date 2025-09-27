import Image from "next/image";
import Link from "next/link";

import { Image as ImageType } from "@/types/Common";
import { Address } from "@/types/RentalUnit";
import { RentalPrice } from "@/types/Listing";
import { TranslateRentalPriceChargeInterval } from "@/lib/utils";

interface Props {
  id: string;
  image: ImageType;
  address: Address;
  rentalPrice: RentalPrice;
}

export default function ListingCard({ id, image, address, rentalPrice }: Props) {
  return (
    <Link className="space-y-2" href={`/listings/${id}`}>
      <div className="relative aspect-square">
        <Image fill src={image.url} alt={image.altText} />
      </div>
      <p className="font-semibold">
        Rum på {address.street} i {address.city}
      </p>
      <p>
        {rentalPrice.amount} SEK per {TranslateRentalPriceChargeInterval(rentalPrice.chargeInterval)}
      </p>
    </Link>
  );
}
