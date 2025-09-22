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

interface Props {
  heading: string;
  submitLabel: string;
  existingData?: RentalUnitData;
}

export default function RentalUnitForm({ heading, submitLabel, existingData }: Props) {
  const methods = useForm<RentalUnitData>({
    resolver: zodResolver(rentalUnitSchema),
    defaultValues: existingData,
  });

  async function handleSubmit(data: RentalUnitData) {
    await createRentalUnit(data);
  }

  return (
    <Form methods={methods} onSubmit={handleSubmit} heading={heading}>
      <div className="grid grid-cols-2 gap-6">
        <Block className="space-y-6">
          <AboutSection />
          <AdressSection />
        </Block>
        <Block>
          <FormSection heading="Bilder på bostaden">
            <ImageUploader id="imageUrls" currentImageUrls={existingData?.imageUrls} />
          </FormSection>
        </Block>

        <Button color="secondary" type="submit">
          {submitLabel}
        </Button>
      </div>
    </Form>
  );
}

function AboutSection() {
  const rentalUnitTypeOptions = [
    { value: "room", label: "Rum" },
    { value: "apartment", label: "Lägenhet" },
    { value: "house", label: "Hus" },
  ];

  return (
    <FormSection heading="Om bostaden">
      <SelectField id="type" label="Boendetyp" options={rentalUnitTypeOptions} />
      <div className="grid grid-cols-2 gap-4">
        <NumberField id="numberOfRooms" label="Antal rum" />
        <NumberField id="sizeSquareMeters" label="Storlek" />
      </div>
    </FormSection>
  );
}

function AdressSection() {
  return (
    <FormSection heading="Adress">
      <div className="grid grid-cols-2 gap-4">
        <TextField id="address.street" label="Gatuadress" />
        <TextField id="address.houseNumber" label="Husnummer" />
      </div>
      <TextField id="address.city" label="Stad" />
    </FormSection>
  );
}
