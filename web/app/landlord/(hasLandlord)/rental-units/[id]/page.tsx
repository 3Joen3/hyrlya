import Page from "@/components/Page";
import { getAuthenticated } from "@/lib/api/server";
import { RentalUnitDetails } from "@/types/RentalUnit";
import RentalUnitForm from "../create/components/RentalUnitForm";

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
      <RentalUnitForm />
    </Page>
  );
}
