import { getAuthenticated } from "@/lib/api/server";
import { redirect } from "next/navigation";

export default async function HasLandlordLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const response = await getAuthenticated("my/landlord");
  if (response.status === 404) redirect("/landlord");

  return <>{children}</>;
}
