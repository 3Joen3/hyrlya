"use client";

import Block from "@/components/Block";
import Form from "@/components/forms/Form";
import FormSection from "@/components/forms/FormSection";
import FormSubmit from "@/components/forms/FormSubmit";
import NumberField from "@/components/forms/NumberField";
import SelectField from "@/components/forms/SelectField";

import { createListing } from "@/lib/actions/listings";
import { ListingData, listingSchema } from "@/lib/schemas/listingSchema";
import { TranslateRentalUnitType } from "@/lib/utils";
import { RentalUnitSummary } from "@/types/RentalUnit";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";

interface Props {
  rentalUnits: RentalUnitSummary[];
}

export default function ListingForm({ rentalUnits }: Props) {
  const methods = useForm<ListingData>({
    resolver: zodResolver(listingSchema),
  });

  async function handleSubmit(data: ListingData) {
    await createListing(data);
  }

  return (
    <Form className="space-y-6" methods={methods} onSubmit={handleSubmit}>
      <Block>
        <FormSection>
          <RentalUnitSelect rentalUnits={rentalUnits} />
          <div className="grid grid-cols-2 gap-4">
            <NumberField id="price" label="Pris" />
            <ChargeIntervalSelect />
          </div>
        </FormSection>
      </Block>
      <FormSubmit label="Spara" loadingLabel="Sparar" />
    </Form>
  );
}

function RentalUnitSelect({ rentalUnits }: { rentalUnits: RentalUnitSummary[] }) {
  const options = rentalUnits.map((rentalUnit) => {
    const type = TranslateRentalUnitType(rentalUnit.type);
    const address = rentalUnit.address;
    const fullAddress = `${address.street} ${address.houseNumber} i ${address.city}`;

    return {
      value: rentalUnit.id,
      label: `${type} på ${fullAddress}`,
    };
  });

  return <SelectField id="rentalUnitId" options={options} label="Välj hyresobjekt" />;
}

function ChargeIntervalSelect() {
  const options = [
    {
      value: "daily",
      label: "Per dag",
    },
    {
      value: "weekly",
      label: "Per vecka",
    },
    {
      value: "monthly",
      label: "Per månad",
    },
  ];

  return <SelectField id="chargeInterval" label="Debiteringsintervall" options={options} />;
}
