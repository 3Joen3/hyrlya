import Page from "@/components/Page";
import ImageCarousel from "@/ui/ImageCarousel";
import LandlordContact from "@/ui/LandlordContact";
import Block from "@/components/Block";

import { get } from "@/lib/api/client";
import { ListingDetails } from "@/types/Listing";
import { BanknotesIcon, MapPinIcon } from "@heroicons/react/24/outline";
import { TranslateRentalPriceChargeInterval } from "@/lib/utils";

interface Props {
  params: {
    id: string;
  };
}

export default async function page({ params }: Props) {
  const { id } = await params;

  const listing = await get<ListingDetails>(`listings/${id}`);

  return (
    <Page className="grid grid-cols-2 gap-6">
      <ImageCarousel images={listing.rentalUnit.images} />
      <DescriptionSection description={listing.rentalUnit.description} />

      <div className="flex gap-4 items-start">
        <InfoSection listing={listing} />
        <LandlordContact {...listing.landlord} />
      </div>
    </Page>
  );
}

function InfoSection({ listing }: { listing: ListingDetails }) {
  const address = listing.rentalUnit.address;
  const rentalPrice = listing.rentalPrice;

  return (
    <Block className="w-1/2 space-y-2">
      <h1 className="text-xl font-semibold">Info</h1>
      <p>Antal rum: {listing.rentalUnit.numberOfRooms}</p>
      <p>Storlek: {listing.rentalUnit.sizeSquareMeters}</p>

      <div className="flex items-center gap-2">
        <BanknotesIcon className="size-5" />
        <p>
          {rentalPrice.amount} kr/
          {TranslateRentalPriceChargeInterval(rentalPrice.chargeInterval)}
        </p>
      </div>
      <div className="flex items-center gap-2">
        <MapPinIcon className="size-5" />
        <p>
          {address.street} {address.houseNumber}, {address.city}
        </p>
      </div>
    </Block>
  );
}

function DescriptionSection({ description }: { description: string }) {
  return (
    <Block>
      <h2>Beskrivning</h2>
      <p>{description}</p>
    </Block>
  );
}
