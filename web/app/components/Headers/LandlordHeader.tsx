import Header from "./Header";
import NavLink from "../NavLink";

export default function LandlordHeader() {
  const headerLinks = [{ href: "landlord/listings", title: "Annonser" }];

  return (
    <Header className="gap-14" logoHref="/landlord">
      <div className="space-x-6">
        {headerLinks.map((link, index) => (
          <NavLink
            key={`header-link-${index}`}
            href={link.href}
            color="primary"
            className="px-4"
          >
            {link.title}
          </NavLink>
        ))}
      </div>
    </Header>
  );
}
