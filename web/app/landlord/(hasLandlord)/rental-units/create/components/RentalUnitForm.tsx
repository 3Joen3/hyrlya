"use client";

import { useForm } from "react-hook-form";

import { RentalUnitData, rentalUnitSchema } from "@/lib/schemas/rentalUnitSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { createRentalUnit } from "@/lib/actions/rental-units";

import Block from "@/components/Block";
import Form from "@/components/forms/Form";
import FormSection from "@/components/forms/FormSection";
import NumberField from "@/components/forms/NumberField";
import SelectField from "@/components/forms/SelectField";
import TextField from "@/components/forms/TextField";
import ImageUploader from "@/components/image-uploader/ImageUploader";
import Button from "@/components/Button";

export default function RentalUnitForm() {
  const methods = useForm<RentalUnitData>({
    resolver: zodResolver(rentalUnitSchema),
  });

  async function handleSubmit(data: RentalUnitData) {
    await createRentalUnit(data);
  }

  return (
    <Form methods={methods} onSubmit={handleSubmit} heading={"Skapa nytt hyresobjekt"}>
      <div className="grid grid-cols-2 gap-6">
        <Block className="space-y-6">
          <AboutSection />
          <AdressSection />
        </Block>
        <Block>
          <FormSection heading="Bilder på bostaden">
            <ImageUploader id="imageUrls" />
          </FormSection>
        </Block>

        <Button color="secondary" type="submit">
          Skapa hyresobjekt
        </Button>
      </div>
    </Form>
  );
}

function AboutSection() {
  const rentalUnitTypeOptions = [
    { value: "1", label: "Rum" },
    { value: "2", label: "Lägenhet" },
    { value: "3", label: "Hus" },
  ];

  return (
    <FormSection heading="Om bostaden">
      <SelectField id="type" label="Boendetyp" options={rentalUnitTypeOptions} />
      <div className="grid grid-cols-2 gap-4">
        <NumberField id="rooms" label="Antal rum" />
        <NumberField id="sizeSquareMeters" label="Storlek" />
      </div>
    </FormSection>
  );
}

function AdressSection() {
  return (
    <FormSection heading="Adress">
      <div className="grid grid-cols-2 gap-4">
        <TextField id="street" label="Gatuadress" />
        <TextField id="houseNumber" label="Husnummer" />
      </div>
      <TextField id="city" label="Stad" />
    </FormSection>
  );
}
