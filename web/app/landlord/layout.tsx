import LandlordHeader from "@/components/headers/LandlordHeader";

import { EdgeStoreProvider } from "@/lib/edgestore";

export default async function LandlordLayout({ children }: { children: React.ReactNode }) {
  return (
    <>
      <LandlordHeader />
      <EdgeStoreProvider>{children}</EdgeStoreProvider>
    </>
  );
}
