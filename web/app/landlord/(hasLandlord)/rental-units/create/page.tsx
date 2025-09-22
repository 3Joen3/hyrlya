import Page from "@/components/Page";
import RentalUnitForm from "@/ui/forms/RentalUnitForm";

export default function page() {
  return (
    <Page heading="Skapa hyresobjekt" className="">
      <RentalUnitForm />
    </Page>
  );
}
