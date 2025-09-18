"use client";

import { useForm } from "react-hook-form";

import { RentalUnitData, rentalUnitSchema } from "@/lib/schemas/rentalUnitSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { createRentalUnit } from "@/lib/actions/rental-units";

import Block from "../Block";
import Form from "../forms/Form";
import PageHeading from "../PageHeading";
import FormSection from "../forms/FormSection";
import NumberField from "../forms/NumberField";
import SelectField from "../forms/SelectField";
import TextField from "../forms/TextField";
import ImageUploader from "../image-uploader/ImageUploader";
import Button from "../Button";

export default function RentalUnitForm() {
  const methods = useForm<RentalUnitData>({
    resolver: zodResolver(rentalUnitSchema),
  });

  async function handleSubmit(data: RentalUnitData) {
    await createRentalUnit(data);
  }

  return (
    <Form
      className="grid grid-cols-2 gap-4"
      methods={methods}
      onSubmit={handleSubmit}
      heading={"Skapa nytt hyresobjekt"}
    >
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
