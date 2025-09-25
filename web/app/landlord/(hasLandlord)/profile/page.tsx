import Page from "@/components/Page";
import PageTopRow from "@/components/PageTopRow";
import ProfileForm from "@/ui/forms/ProfileForm";

export default function page() {
  return (
    <Page>
      <PageTopRow heading="Redigera profil" />
      <ProfileForm className=""/>
    </Page>
  );
}
