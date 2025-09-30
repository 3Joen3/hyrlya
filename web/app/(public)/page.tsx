import ListingCard from "@/ui/ListingCard";
import Page from "@/components/Page";
import PageTopRow from "@/components/PageTopRow";

import { get } from "@/lib/api/client";
import { ListingSummary } from "@/types/Listing";

export default async function Home() {
  const listings = await get<ListingSummary[]>("listings?page=1&size=10");
  return (
    <Page>
      <PageTopRow heading="Bostadsannonser" />

      <div className="grid grid-cols-4 gap-4">
        {listings.map((listing) => (
          <ListingCard key={listing.id} {...listing} image={listing.image} />
        ))}
      </div>
    </Page>
  );
}
