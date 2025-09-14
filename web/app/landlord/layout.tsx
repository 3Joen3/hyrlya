import LandlordHeader from "../components/Headers/LandlordHeader";

import { EdgeStoreProvider } from "@/lib/edgestore";

export default function LandlordLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <>
      <LandlordHeader />
      <EdgeStoreProvider>{children}</EdgeStoreProvider>
    </>
  );
}
