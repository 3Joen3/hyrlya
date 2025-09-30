import Page from "@/components/Page";
import PageTopRow from "@/components/PageTopRow";
import ProfileForm from "@/ui/forms/ProfileForm";

import { getAuthenticated } from "@/lib/api/server";
import { LandlordProfile } from "@/types/Landlord";

export default async function page() {
  const response = await getAuthenticated("my/landlord");
  const landlordProfile = (await response.json()) as LandlordProfile;

  return (
    <Page>
      <PageTopRow heading="Redigera profil" />
      <ProfileForm existingData={landlordProfile} />
    </Page>
  );
}
