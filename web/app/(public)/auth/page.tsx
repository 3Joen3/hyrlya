import { cookies } from "next/headers";
import { redirect } from "next/navigation";
import Page from "../../components/Page";
import AuthForm from "../../components/Forms/AuthForm";

export default async function page() {
  const cookieStore = await cookies();
  if (cookieStore.get("__Host-accessToken")?.value) {
    redirect("/landlord");
  }

  return (
    <Page>
      <AuthForm className="w-full lg:w-1/3 justify-self-center mt-10" />
    </Page>
  );
}
