import Page from "@/components/Page";
import RentalUnitForm from "@/components/rental-units/RentalUnitForm";

export default function page() {
  return (
    <Page heading="Skapa nytt hyresobjekt">
      <RentalUnitForm />
    </Page>
  );
}
