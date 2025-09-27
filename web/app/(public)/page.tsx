import Block from "@/components/Block";
import Page from "@/components/Page";
import PageTopRow from "@/components/PageTopRow";

import { get } from "@/lib/api/client";
import { ListingSummary } from "@/types/Listing";
import ListingCard from "@/ui/ListingCard";

export default async function Home() {
  const listings = await get<ListingSummary[]>("listings?page=1&size=10");
  return (
    <Page>
      <PageTopRow heading="Bostadsannonser" />

      <div className="grid grid-cols-4 gap-4">
        {listings.map((listing) => (
          <Block key={listing.id}>
            <ListingCard {...listing} image={listing.image} />
          </Block>
        ))}
      </div>
    </Page>
  );
}
