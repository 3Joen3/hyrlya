import NavLink from "../NavLink";
import Header from "./Header";
import Link from "next/link";

export default function LandlordHeader() {
  return (
    <Header className="gap-12" logoHref="/landlord">
      <div className="space-x-6">
        <NavLink href="/landlord/listings">Annonser</NavLink>
      </div>
    </Header>
  );
}
