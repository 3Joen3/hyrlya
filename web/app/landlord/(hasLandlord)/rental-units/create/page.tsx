import Page from "@/components/Page";
import PageTopRow from "@/components/PageTopRow";
import RentalUnitForm from "@/ui/forms/RentalUnitForm";

export default async function page() {
  return (
    <Page>
      <PageTopRow heading="Skapa hyresobjekt" />
      <RentalUnitForm />
    </Page>
  );
}
