import Page from "@/components/Page";
import RentalUnitForm from "@/ui/forms/RentalUnitForm";

export default function page() {
  return (
    <Page>
      <RentalUnitForm heading="Kom igång som hyresvärd" submitLabel="Skapa hyresobjekt" />
    </Page>
  );
}
