import Page from "@/components/Page";
import PageTopRow from "@/components/PageTopRow";
import ProfileForm from "@/ui/forms/ProfileForm";

export default function page() {
  return (
    <Page>
      <PageTopRow heading="Kom igång som hyresvärd" />
      <ProfileForm className="w-full md:w-3/4 lg:w-2/3" />
    </Page>
  );
}
