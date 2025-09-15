import { getAuthenticated } from "@/lib/api/server";
import { redirect } from "next/navigation";

export default async function HasLandlordLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const response = await getAuthenticated("landlords");
  if (response.status === 404) redirect("/landlord/profile/create");

  return <>{children}</>;
}
