import Image from "next/image";
import Link from "next/link";
import Block from "@/components/Block";

import { Image as ImageType } from "@/types/Common";
import { Address } from "@/types/RentalUnit";
import { RentalPrice } from "@/types/Listing";
import { TranslateRentalPriceChargeInterval, TranslateRentalUnitType } from "@/lib/utils";

interface Props {
  id: string;
  image: ImageType;
  address: Address;
  rentalPrice: RentalPrice;
}

export default function ListingCard({ id, image, address, rentalPrice }: Props) {
  return (
    <Link href={`/listings/${id}`}>
      <div className="relative aspect-square shadow">
        <Image fill src={image.url} alt={image.altText} />
      </div>
      <Block className="space-y-1">
        <p className="font-semibold">
          {address.street} i {address.city}
        </p>
        <p>
          {rentalPrice.amount} kr/
          {TranslateRentalPriceChargeInterval(rentalPrice.chargeInterval)}
        </p>
      </Block>
    </Link>
  );
}
