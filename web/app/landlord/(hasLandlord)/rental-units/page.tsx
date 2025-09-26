import Page from "@/components/Page";
import Link from "next/link";
import Block from "@/components/Block";
import PageTopRow from "@/components/PageTopRow";

import { getAuthenticated } from "@/lib/api/server";
import { RentalUnitSummary } from "@/types/RentalUnit";
import { TranslateRentalUnitType } from "@/lib/utils";

export default async function page() {
  const response = await getAuthenticated("my/rental-units");
  const rentalUnits = (await response.json()) as RentalUnitSummary[];

  return (
    <Page>
      <PageTopRow heading="Dina hyresobjekt">
        <Link href="/landlord/rental-units/create" className="btn-primary btn-color-primary">
          Skapa hyresobjekt
        </Link>
      </PageTopRow>
      <div className="space-y-4">
        {rentalUnits.map((rentalUnit) => (
          <RentalUnitContainer key={rentalUnit.id} rentalUnit={rentalUnit} />
        ))}
      </div>
    </Page>
  );
}

function RentalUnitContainer({ rentalUnit }: { rentalUnit: RentalUnitSummary }) {
  const swedishType = TranslateRentalUnitType(rentalUnit.type);
  const address = rentalUnit.address;

  return (
    <Link className="block" href={`/landlord/rental-units/${rentalUnit.id}`}>
      <Block>
        <p>Typ: {swedishType}</p>
        <p>
          Adress: {address.street} {address.houseNumber}, {address.city}
        </p>
      </Block>
    </Link>
  );
}
