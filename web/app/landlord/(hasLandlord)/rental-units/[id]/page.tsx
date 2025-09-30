import Page from "@/components/Page";
import RentalUnitForm from "@/ui/forms/RentalUnitForm";

import { getAuthenticated } from "@/lib/api/server";
import { RentalUnitDetails } from "@/types/RentalUnit";
import PageTopRow from "@/components/PageTopRow";

interface Props {
  params: {
    id: string;
  };
}

export default async function page({ params }: Props) {
  const { id } = await params;

  const response = await getAuthenticated(`my/rental-units/${id}`);
  const rentalUnit = (await response.json()) as RentalUnitDetails;

  return (
    <Page>
      <PageTopRow heading="Redigera hyresobjekt" />
      <RentalUnitForm existingData={rentalUnit} />
    </Page>
  );
}
