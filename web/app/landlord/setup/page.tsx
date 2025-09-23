import Page from "@/components/Page";
import ProfileForm from "@/ui/forms/ProfileForm";

export default function page() {
  return (
    <Page heading="Kom igång som hyresvärd" className="flex">
      <ProfileForm className="w-full md:w-3/4 lg:w-2/3" />
    </Page>
  );
}
