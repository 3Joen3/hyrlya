import Page from "@/components/Page";
import PageTopRow from "@/components/PageTopRow";
import Link from "next/link";

export default function page() {
  return (
    <Page>
      <PageTopRow heading="Dina annonser">
        <Link className="btn-primary btn-color-primary" href="/landlord/listings/create">
          Skapa annons
        </Link>
      </PageTopRow>
    </Page>
  );
}
