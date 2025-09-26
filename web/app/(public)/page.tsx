import Page from "@/components/Page";
import PageTopRow from "@/components/PageTopRow";

import { get } from "@/lib/api/client";
import { ListingSummary } from "@/types/Listing";

export default async function Home() {
  const listings = await get<ListingSummary[]>("listings?page=1&size=10");
  return (
    <Page>
      <PageTopRow heading="Bostadsannonser" />

      {listings.map((listing) => (
        <p>{listing.id}</p>
      ))}
    </Page>
  );
}
