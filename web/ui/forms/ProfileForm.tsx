"use client";

import Form from "@/components/forms/Form";
import Block from "@/components/Block";
import TextField from "@/components/forms/TextField";
import ProfileImage from "../ProfileImage";
import FormSection from "@/components/forms/FormSection";
import FormSubmit from "@/components/forms/FormSubmit";

import { useForm, useFormContext } from "react-hook-form";
import { ProfileData, profileSchema } from "@/lib/schemas/profileSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { createLandlord } from "@/lib/actions/profile";
import { useEdgeStore } from "@/lib/edgestore";
import { useRef, useState } from "react";

interface Props {
  className: string;
}

export default function ProfileForm({ className }: Props) {
  const methods = useForm<ProfileData>({
    resolver: zodResolver(profileSchema),
  });

  async function handleSubmit(data: ProfileData) {
    await createLandlord(data);
  }

  return (
    <Form className={`${className} space-y-6`} methods={methods} onSubmit={handleSubmit}>
      <Block className="space-y-6">
        <FormSection>
          <TextField id="name" label="Namn" />
          <TextField id="phoneNumber" label="Telefonnummer" />
          <TextField id="emailAddress" label="Email address" />
        </FormSection>

        <ProfileImageSection />
      </Block>

      <FormSubmit label="Spara" loadingLabel="Sparar..." />
    </Form>
  );
}

function ProfileImageSection() {
  const { edgestore } = useEdgeStore();
  const fileInputRef = useRef<HTMLInputElement>(null);

  const [profileImageUrl, setProfileImageUrl] = useState<string>();
  const { setValue } = useFormContext();

  async function handleSelectedImage(e: React.ChangeEvent<HTMLInputElement>) {
    const file = e.target.files?.[0];
    if (!file) return;

    const response = await edgestore.publicImages.upload({
      file,
      input: { type: "profile" },
    });

    setProfileImageUrl(response.url);
    setValue("profileImageUrl", response.url);
  }

  return (
    <FormSection heading="Profilbild">
      <div className="flex items-center gap-4">
        <input
          className="hidden"
          type="file"
          accept="image/*"
          ref={fileInputRef}
          onChange={handleSelectedImage}
        />
        <ProfileImage className="h-40 w-40" imageUrl={profileImageUrl} />
        <button
          className="btn-primary btn-color-secondary"
          onClick={() => fileInputRef.current?.click()}
        >
          Välj profilbild
        </button>
      </div>
    </FormSection>
  );
}
