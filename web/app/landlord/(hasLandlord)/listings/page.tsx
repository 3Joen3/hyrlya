import Page from "@/components/Page";
import PageTopRow from "@/components/PageTopRow";
import Link from "next/link";

import { getAuthenticated } from "@/lib/api/server";
import { ListingSummary } from "@/types/Listing";

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
      <div className="space-y-4">
        {listings.map((listing) => (
          <ListingContainer key={listing.id} listing={listing} />
        ))}
      </div>
    </Page>
  );
}

function ListingContainer({ listing }: { listing: ListingSummary }) {
  return <div>{listing.id}</div>;
}
