import Page from "@/components/Page";
import AuthForm from "@/app/components/forms/AuthForm";

import { getAccessToken } from "@/lib/api/server";
import { redirect } from "next/navigation";

export default async function page() {
  if (await getAccessToken()) {
    redirect("/landlord");
  }

  return (
    <Page>
      <AuthForm className="w-full md:justify-self-center md:w-3/4 lg:w-2/5" />
    </Page>
  );
}
