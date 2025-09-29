import Page from "@/components/Page";
import ImageCarousel from "@/ui/ImageCarousel";
import Block from "@/components/Block";
import ListingPageSection from "@/ui/ListingPage.tsx/ListingPageSection";
import LandlordContact from "@/ui/ListingPage.tsx/LandlordContact";
import InfoBulletPoints from "@/ui/ListingPage.tsx/InfoBulletPoints";

import { get } from "@/lib/api/client";
import { ListingDetails } from "@/types/Listing";

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
      <div className="space-y-4">
        <HigherSection listing={listing} />
        <LowerSection listing={listing} />
      </div>
    </Page>
  );
}

function HigherSection({ listing }: { listing: ListingDetails }) {
  return (
    <Block className="space-y-5">
      <ListingPageSection heading="Beskrivning">
        <p>{listing.rentalUnit.description}</p>
      </ListingPageSection>
      <InfoBulletPoints {...listing} />
    </Block>
  );
}

function LowerSection({ listing }: { listing: ListingDetails }) {
  return (
    <Block className="space-y-5">
      {listing.landlordNote && (
        <ListingPageSection heading="Profil på önskad hyresgäst">
          {listing.landlordNote}
        </ListingPageSection>
      )}

      <LandlordContact {...listing.landlord} />
    </Block>
  );
}
