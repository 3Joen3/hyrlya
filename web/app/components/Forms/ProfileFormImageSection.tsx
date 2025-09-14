import ProfileImage from "../Profile/ProfileImage";
import Button from "../Button";

import { useEdgeStore } from "@/lib/edgestore";
import { useRef, useState } from "react";
import { useFormContext } from "react-hook-form";
import SectionHeading from "../Headings/SectionHeading";

export default function ProfileFormImageSection() {
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
    <>
      <SectionHeading heading="Profilbild" />
      <input
        className="hidden"
        type="file"
        accept="image/*"
        ref={fileInputRef}
        onChange={handleSelectedImage}
      />

      <ProfileImage className="w-1/2" imageUrl={profileImageUrl} />

      <Button className="w-1/2" onClick={() => fileInputRef.current?.click()}>
        Välj profilbild
      </Button>
    </>
  );
}
