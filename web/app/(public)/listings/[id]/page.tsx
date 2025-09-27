import Page from "@/components/Page";
import ImageCarousel from "@/ui/ImageCarousel";

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
    <Page>
      <ImageCarousel className="w-1/2" images={listing.images} />
    </Page>
  );
}
