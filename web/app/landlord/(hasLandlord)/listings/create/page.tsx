import Page from "@/components/Page";
import PageTopRow from "@/components/PageTopRow";
import ListingForm from "@/ui/forms/ListingForm";

import { getAuthenticated } from "@/lib/api/server";
import { RentalUnitSummary } from "@/types/RentalUnit";

export default async function page() {
  const response = await getAuthenticated("my/rental-units");
  const rentalUnits = (await response.json()) as RentalUnitSummary[];

  return (
    <Page>
      <PageTopRow heading="Skapa bostadsannons" />
      <ListingForm rentalUnits={rentalUnits} />
    </Page>
  );
}
