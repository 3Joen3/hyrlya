import Page from "@/components/Page";
import Link from "next/link";
import Block from "@/components/Block";

import { getAuthenticated } from "@/lib/api/server";
import { RentalUnitSummary } from "@/types/RentalUnit";

export default async function page() {
  const response = await getAuthenticated("my/rental-units");
  const rentalUnits = (await response.json()) as RentalUnitSummary[];

  return (
    <Page heading="Dina hyresobjekt" className="grid grid-cols-4 gap-4 items-start">
      {rentalUnits.map((rentalUnit, index) => (
        <RentalUnitContainer key={index} rentalUnit={rentalUnit} />
      ))}
    </Page>
  );
}

function RentalUnitContainer({ rentalUnit }: { rentalUnit: RentalUnitSummary }) {
  const swedishType = TranslateType(rentalUnit.type);
  const address = rentalUnit.address;

  return (
    <Link href={`/landlord/rental-units/${rentalUnit.id}`}>
      <Block>
        <p>Typ: {swedishType}</p>
        <p>
          Adress: {address.street} {address.houseNumber}, {address.city}
        </p>
      </Block>
    </Link>
  );
}

function TranslateType(englishType: string) {
  if (englishType === "Room") return "Rum";
  if (englishType === "Apartment") return "Lägenhet";
  return "Hus";
}
