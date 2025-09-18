import Page from "@/components/Page";
import ProfileForm from "../components/profile/ProfileForm";

export default function page() {
  return (
    <Page>
      <ProfileForm heading="Kom igång som hyresvärd" className="w-2/3 justify-self-center" />
    </Page>
  );
}
