import Header from "../components/Header";
import NavLink from "../components/NavLink";

import { EdgeStoreProvider } from "@/lib/edgestore";

export default function LandlordLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <>
      <LayoutHeader />
      <EdgeStoreProvider>{children}</EdgeStoreProvider>
    </>
  );
}

function LayoutHeader() {
  return (
    <Header className="gap-12" logoHref="/landlord">
      <div className="space-x-6">
        <NavLink href="/landlord/listings">Annonser</NavLink>
      </div>
    </Header>
  );
}
