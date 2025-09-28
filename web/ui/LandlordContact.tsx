import Image from "next/image";
import Block from "@/components/Block";

import { PhoneIcon, EnvelopeIcon } from "@heroicons/react/24/outline";
import { Image as ImageType } from "@/types/Common";

interface Props {
  name: string;
  image: ImageType;
  phone: string;
  email: string;
}

export default function LandlordContact({ name, image, phone, email }: Props) {
  return (
    <Block className="flex items-center gap-4">
      <LeftSide name={name} phone={phone} email={email} />
      <ProfileImage image={image} />
    </Block>
  );
}

function LeftSide({ name, phone, email }: { name: string; phone: string; email: string }) {
  return (
    <div className="space-y-2">
      <h1 className="text-xl font-semibold">Kontakta hyresvärden!</h1>
      <ContactDetails name={name} phone={phone} email={email} />
    </div>
  );
}

function ContactDetails({ name, phone, email }: { name: string; phone: string; email: string }) {
  return (
    <div className="space-y-1">
      <p>{name}</p>
      <div className="flex items-center gap-2">
        <PhoneIcon className="size-5" />
        <p>{phone}</p>
      </div>
      <div className="flex items-center gap-2">
        <EnvelopeIcon className="size-5" />
        <p>{email}</p>
      </div>
    </div>
  );
}

function ProfileImage({ image }: { image: ImageType }) {
  return (
    <div className="relative w-30 h-30 rounded-full overflow-hidden">
      <Image fill className="object-cover" src={image.url} alt={image.altText} />
    </div>
  );
}
