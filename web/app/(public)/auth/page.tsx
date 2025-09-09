import { getAccessToken } from "@/lib/auth/cookies";
import { redirect } from "next/navigation";
import Page from "../../components/Page";
import AuthForm from "../../components/Forms/AuthForm";

export default async function page() {
  if (await getAccessToken()) {
    redirect("/landlord");
  }

  return (
    <Page>
      <AuthForm className="w-full lg:w-1/3 justify-self-center mt-10" />
    </Page>
  );
}
