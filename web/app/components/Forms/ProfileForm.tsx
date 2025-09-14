"use client";

import Form from "./Form";
import PageHeading from "../Headings/PageHeading";
import Block from "../Block";
import SectionHeading from "../Headings/SectionHeading";
import TextField from "./TextField";
import ProfileFormImageSection from "./ProfileFormImageSection";
import Button from "../Button";

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
      className={`${className} space-y-4`}
      methods={methods}
      onSubmit={handleSubmit}
    >
      <PageHeading heading={heading} />
      <div className="grid grid-cols-3 gap-10">
        <Block className="col-span-2 space-y-4">
          <SectionHeading heading="Profil info" />
          <TextField id="name" label="Namn" />
          <TextField id="phoneNumber" label="Telefonnummer" />
          <TextField id="emailAddress" label="Email address" />
        </Block>

        <Block className="col-span-1 flex flex-col justify-center items-center space-y-4">
          <ProfileFormImageSection />
        </Block>
      </div>
      <Button className="w-1/3" type="submit" color="secondary">
        Spara
      </Button>
    </Form>
  );
}
