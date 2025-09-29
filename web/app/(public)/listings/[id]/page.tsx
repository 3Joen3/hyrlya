import Page from "@/components/Page";
import ImageCarousel from "@/ui/ImageCarousel";
import LandlordContact from "@/ui/LandlordContact";
import Block from "@/components/Block";

import { get } from "@/lib/api/client";
import { ListingDetails } from "@/types/Listing";
import { BanknotesIcon, MapPinIcon, ArrowsPointingOutIcon } from "@heroicons/react/24/outline";
import { TranslateRentalPriceChargeInterval } from "@/lib/utils";

interface Props {
  params: {
    id: string;
  };
}

export default async function page({ params }: Props) {
  const { id } = await params;

  const listing = await get<ListingDetails>(`listings/${id}`);

  const rentalUnit = listing.rentalUnit;

  return (
    <Page className="grid grid-cols-2 gap-6">
      <ImageCarousel images={listing.rentalUnit.images} />

      <div className="space-y-4">
        <Block className="space-y-6">
          <DescriptionSection description={rentalUnit.description} />
          <InfoSections listing={listing} />
        </Block>
        <LandlordContact {...listing.landlord} />
      </div>
    </Page>
  );
}

function DescriptionSection({ description }: { description: string }) {
  return (
    <Section heading="Beskrivning">
      <p>{description}</p>
    </Section>
  );
}

function InfoSections({ listing }: { listing: ListingDetails }) {
  const address = listing.rentalUnit.address;
  const rentalPrice = listing.rentalPrice;
  const rentalUnit = listing.rentalUnit;

  return (
    <Section className="space-y-2" heading="Info">
      <IconRow>
        <MapPinIcon className="size-6" />
        <p>
          {address.street} {address.houseNumber}, {address.city}
        </p>
      </IconRow>
      <IconRow>
        <BanknotesIcon className="size-6" />
        <p>
          {rentalPrice.amount} kr/
          {TranslateRentalPriceChargeInterval(rentalPrice.chargeInterval)}
        </p>
      </IconRow>
      <IconRow>
        <ArrowsPointingOutIcon className="size-6" />
        <p>
          {rentalUnit.numberOfRooms} rum, {rentalUnit.sizeSquareMeters} m²
        </p>
      </IconRow>
    </Section>
  );
}

function IconRow({ children }: { children: React.ReactNode }) {
  return <div className="flex items-center gap-2">{children}</div>;
}

function Section({
  className,
  heading,
  children,
}: {
  className?: string;
  heading: string;
  children: React.ReactNode;
}) {
  return (
    <div className="space-y-2">
      <h2 className="text-xl font-bold">{heading}</h2>
      <div className={className}>{children}</div>
    </div>
  );
}
