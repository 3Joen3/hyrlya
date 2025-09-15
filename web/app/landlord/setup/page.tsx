import Page from "@/components/Page";
import ProfileForm from "@/app/landlord/components/profile/ProfileForm";

export default function page() {
  return (
    <Page>
      <ProfileForm className="w-2/3" heading="Kom igång som hyresvärd" />
    </Page>
  );
}
