import Page from "@/components/Page";
import Link from "next/link";

import { getAuthenticated } from "@/lib/api/server";
import { RentalUnitSummary } from "@/types/RentalUnit";

export default async function page() {
  const response = await getAuthenticated("my/rental-units");
  const rentalUnits = (await response.json()) as RentalUnitSummary[];

  return (
    <Page>
      {rentalUnits.map((rentalUnit, index) => (
        <RentalUnitContainer key={index} rentalUnit={rentalUnit} />
      ))}
    </Page>
  );
}

function RentalUnitContainer({ rentalUnit }: { rentalUnit: RentalUnitSummary }) {
  const address = rentalUnit.address;

  return (
    <Link href={`/landlord/rental-units/${rentalUnit.id}`}>
      {address.city} {address.street} {address.houseNumber}
    </Link>
  );
}
