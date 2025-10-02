import Page from "@/components/Page";
import PageTopRow from "@/components/PageTopRow";
import Link from "next/link";
import Block from "@/components/Block";

import { getAuthenticated } from "@/lib/api/server";
import { ListingSummary } from "@/types/Listing";
import { TranslateRentalPriceChargeInterval } from "@/lib/utils";

export default async function page() {
  const response = await getAuthenticated("my/listings");
  const listings = (await response.json()) as ListingSummary[];

  return (
    <Page>
      <PageTopRow heading="Dina annonser">
        <Link className="btn-primary btn-color-primary" href="/landlord/listings/create">
          Skapa annons
        </Link>
      </PageTopRow>
      {listings.length === 0 ? (
        <p>Du har inga annonser ännu. Skapa en!</p>
      ) : (
        <div className="space-y-4">
          {listings.map((listing) => (
            <ListingContainer key={listing.id} listing={listing} />
          ))}
        </div>
      )}
    </Page>
  );
}

function ListingContainer({ listing }: { listing: ListingSummary }) {
  const address = listing.address;
  const rentalPeriod = TranslateRentalPriceChargeInterval(listing.rentalPrice.chargeInterval);
  return (
    <Link href={`/landlord/listings/${listing.id}`}>
      <Block>
        <p>Uthyrningsperiod: {rentalPeriod!.charAt(0).toUpperCase() + rentalPeriod!.slice(1)}</p>
        <p>
          Adress: {address.street} {address.houseNumber}, {address.city}
        </p>
      </Block>
    </Link>
  );
}
