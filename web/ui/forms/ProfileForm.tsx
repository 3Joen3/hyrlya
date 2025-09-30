"use client";

import Form from "@/components/forms/Form";
import Block from "@/components/Block";
import FormSection from "@/components/forms/FormSection";
import TextField from "@/components/forms/TextField";
import FormSubmit from "@/components/forms/FormSubmit";
import LandlordContact from "../ListingPage.tsx/LandlordContact";
import React from "react";

import { LandlordProfile } from "@/types/Landlord";
import { useForm } from "react-hook-form";
import { ProfileData, profileSchema } from "@/lib/schemas/profileSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { createLandlord } from "@/lib/actions/profile";
import { Image } from "@/types/Common";
import { useEdgeStore } from "@/lib/edgestore";

interface Props {
  existingData?: LandlordProfile;
}

export default function ProfileForm({ existingData }: Props) {
  const methods = useForm<ProfileData>({
    resolver: zodResolver(profileSchema),
    defaultValues: {
      name: existingData?.name,
      emailAddress: existingData?.email,
      phoneNumber: existingData?.phone,
      profileImageUrl: existingData?.image.url,
    },
  });

  const { edgestore } = useEdgeStore();

  async function handleSubmit(data: ProfileData) {
    await createLandlord(data);
  }

  const { watch, setValue } = methods;

  const watchedName = watch("name");
  const watchedPhone = watch("phoneNumber");
  const watchedEmail = watch("emailAddress");
  const watchedImageUrl = watch("profileImageUrl");

  let image: Image | null = null;

  if (watchedImageUrl) {
    image = {
      url: watchedImageUrl,
      altText: "Din profilbild",
    };
  }

  async function handleUploadedImage(e: React.ChangeEvent<HTMLInputElement>) {
    const file = e.target.files?.[0];
    if (!file) return;

    const response = await edgestore.publicImages.upload({
      file,
      input: {
        type: "profile",
      },
    });
    setValue("profileImageUrl", response.url);
  }

  const fileInputRef = React.useRef<HTMLInputElement>(null);

  return (
    <Form className="space-y-6 w-full" methods={methods} onSubmit={handleSubmit}>
      <div className="flex flex-col lg:flex-row w-full gap-4">
        <Block className="flex-1">
          <FormSection heading="Kontaktuppgifter">
            <TextField id="name" label="Namn" />
            <TextField id="phoneNumber" label="Telefonnummer" />
            <TextField id="emailAddress" label="E-postadress" />
          </FormSection>
        </Block>
        <div className="space-y-4">
          <h2 className="text-2xl font-semibold underline">Ditt profilkort</h2>
          <Block>
            <LandlordContact
              name={watchedName}
              email={watchedEmail}
              phone={watchedPhone}
              image={image}
            />
          </Block>
          <input
            type="file"
            className="hidden"
            ref={fileInputRef}
            accept="image/*"
            onChange={handleUploadedImage}
          />
          <button
            onClick={() => fileInputRef.current?.click()}
            type="button"
            className="btn-primary btn-color-secondary"
          >
            Byt profilbild
          </button>
        </div>
      </div>
      <FormSubmit label="Spara" loadingLabel="Sparar..." />
    </Form>
  );
}
