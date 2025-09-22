"use client";

import Form from "@/components/forms/Form";
import Block from "@/components/Block";
import FormSection from "@/components/forms/FormSection";
import TextField from "@/components/forms/TextField";
import ProfileFormImageSection from "./ProfileFormImageSection";
import Button from "@/components/Button";

import { useForm } from "react-hook-form";
import { ProfileData, profileSchema } from "@/lib/schemas/profileSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { createLandlord } from "@/lib/actions/profile";

interface Props {
  className: string;
  heading: string;
}

export default function ProfileForm({ className, heading }: Props) {
  const methods = useForm<ProfileData>({
    resolver: zodResolver(profileSchema),
  });

  async function handleSubmit(data: ProfileData) {
    await createLandlord(data);
  }

  return (
    <Form
      className={`${className} space-y-6`}
      methods={methods}
      onSubmit={handleSubmit}
      heading={heading}
    >
      <div className="flex flex-col gap-6 lg:grid lg:grid-cols-3">
        <Block className="lg:col-span-2">
          <FormSection>
            <TextField id="name" label="Namn" />
            <TextField id="phoneNumber" label="Telefonnummer" />
            <TextField id="emailAddress" label="Email address" />
          </FormSection>
        </Block>
        <Block className="lg:col-span-1 flex flex-col items-center gap-6">
          <ProfileFormImageSection />
        </Block>
      </div>

      <Button className="w-full" color="secondary" type="submit">
        Spara
      </Button>
    </Form>
  );
}
