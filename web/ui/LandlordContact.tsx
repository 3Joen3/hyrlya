import { PhoneIcon, EnvelopeIcon } from "@heroicons/react/24/outline";
import Image from "next/image";

import { Image as ImageType } from "@/types/Common";

interface Props {
  name: string;
  image: ImageType;
}

export default function LandlordContact({ name, image }: Props) {
  return (
    <div className="bg-neutral-100 p-4 grid grid-cols-2">
      <LeftSide name={name} />
      <ProfileImage image={image} />
    </div>
  );
}

function LeftSide({ name }: { name: string }) {
  return (
    <div className="space-y-2">
      <h1 className="text-xl font-semibold">Kontakta hyresvärden!</h1>
      <ContactDetails name={name} />
    </div>
  );
}

function ContactDetails({ name }: { name: string }) {
  return (
    <div className="space-y-1">
      <p>{name}</p>
      <div className="flex items-center gap-2">
        <PhoneIcon className="size-5" />
        <p>+46761661387</p>
      </div>
      <div className="flex items-center gap-2">
        <EnvelopeIcon className="size-5" />
        <p>joalevall@gmail.com</p>
      </div>
    </div>
  );
}

function ProfileImage({ image }: { image: ImageType }) {
  return (
    <div className="rounded-full overflow-hidden relative">
      <Image className="object-cover" src={image.url} alt={image.altText} fill />
    </div>
  );
}
