import Page from "@/app/components/Page";
import NavLink from "@/app/components/NavLink";

export default function page() {
  return (
    <Page>
      <NavLink href="/landlord/listings/create" color="secondary">
        Skapa annons
      </NavLink>
    </Page>
  );
}
