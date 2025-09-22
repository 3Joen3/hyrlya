import Page from "@/components/Page";
import RentalUnitForm from "@/ui/forms/RentalUnitForm";

export default async function page() {
  return (
    <Page heading="Skapa hyresobjekt" className="">
      <RentalUnitForm />
    </Page>
  );
}
