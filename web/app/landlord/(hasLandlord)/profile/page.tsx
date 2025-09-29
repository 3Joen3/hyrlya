import Page from "@/components/Page";
import PageTopRow from "@/components/PageTopRow";
import ProfileForm from "@/ui/forms/ProfileForm";

import { getAuthenticated } from "@/lib/api/server";
import { LandlordDetails } from "@/types/Landlord";

export default async function page() {
  const response = await getAuthenticated("my/landlord");
  const landlord = (await response.json()) as LandlordDetails;

  return (
    <Page>
      <PageTopRow heading="Redigera profil" />
      <ProfileForm existingData={landlord.profile} />
    </Page>
  );
}
