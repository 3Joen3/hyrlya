import Page from "@/components/Page";
import AuthForm from "@/ui/forms/AuthForm";

import { getAccessToken } from "@/lib/api/server";
import { redirect } from "next/navigation";

export default async function page() {
  if (await getAccessToken()) {
    redirect("/landlord/listings");
  }

  return (
    <Page className="w-full md:justify-self-center md:w-3/4 lg:w-2/5">
      <AuthForm />
    </Page>
  );
}
