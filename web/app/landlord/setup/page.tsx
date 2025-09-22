import Page from "@/components/Page";
import ProfileForm from "@/ui/forms/ProfileForm";

export default function page() {
  return (
    <Page heading="Kom igång som hyresvärd" className="">
      <ProfileForm
        heading="Kom igång som hyresvärd"
        className="w-full md:justify-self-center md:w-3/4 lg:w-2/3"
      />
    </Page>
  );
}
