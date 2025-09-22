import Page from "@/components/Page";
import { getAuthenticated } from "@/lib/api/server";
import { RentalUnitDetails } from "@/types/RentalUnit";
import RentalUnitForm from "@/ui/forms/RentalUnitForm";
import { RentalUnitData } from "@/lib/schemas/rentalUnitSchema";

interface Props {
  params: {
    id: string;
  };
}

export default async function page({ params }: Props) {
  const { id } = await params;

  const response = await getAuthenticated(`my/rental-units/${id}`);
  const rentalUnit = (await response.json()) as RentalUnitDetails;

  const existingData: RentalUnitData = {
    address: rentalUnit.address,
    numberOfRooms: rentalUnit.numberOfRooms,
    sizeSquareMeters: rentalUnit.sizeSquareMeters,
    type: rentalUnit.type.toLowerCase() as RentalUnitData["type"],
    imageUrls: rentalUnit.images.map((img) => img.url),
  };

  return (
    <Page>
      <RentalUnitForm existingData={existingData} />
    </Page>
  );
}
