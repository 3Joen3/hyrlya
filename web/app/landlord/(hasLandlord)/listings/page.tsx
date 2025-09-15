import Page from "@/components/Page";
import NavLink from "@/components/NavLink";

export default function page() {
  return (
    <Page>
      <NavLink
        href="/landlord/listings/create"
        variant="buttonPrimary"
        color="buttonSecondary"
      >
        Skapa annons
      </NavLink>
    </Page>
  );
}
