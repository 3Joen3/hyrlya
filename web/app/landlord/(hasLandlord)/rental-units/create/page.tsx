import Page from "@/components/Page";
import RentalUnitForm from "@/ui/forms/RentalUnitForm";

import { RentalUnitData } from "@/lib/schemas/rentalUnitSchema";
import { createRentalUnit } from "@/lib/actions/rental-units";

export default async function page() {
  async function handleSubmit(data: RentalUnitData) {
    await createRentalUnit(data);
  }

  return (
    <Page heading="Skapa hyresobjekt" className="">
      <RentalUnitForm onSubmit={handleSubmit} />
    </Page>
  );
}
