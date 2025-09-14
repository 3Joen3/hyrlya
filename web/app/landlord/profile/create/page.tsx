import Page from "@/app/components/Page";
import ProfileForm from "@/app/components/Forms/ProfileForm";

export default function page() {
  return (
    <Page>
      <ProfileForm className="w-2/3" heading="Kom igång som hyresvärd" />
    </Page>
  );
}
