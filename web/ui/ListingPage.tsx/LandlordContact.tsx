import ListingPageIconRow from "./ListingPageIconRow";
import Image from "next/image";

import { Image as ImageType } from "@/types/Common";
import { EnvelopeIcon, PhoneIcon, UserIcon } from "@heroicons/react/24/outline";

interface Props {
  name: string;
  phone: string;
  email: string;
  image: ImageType;
}

export default function LandlordContact({ name, phone, email, image }: Props) {
  return (
    <div className="flex gap-6">
      <Image src={image.url} alt={image.altText} width={120} height={120} />
      <div className="space-y-3">
        <h2 className="text-xl font-semibold">Kontakta hyresvärden!</h2>
        <Icons name={name} phone={phone} email={email} />
      </div>
    </div>
  );
}

function Icons({ name, phone, email }: { name: string; phone: string; email: string }) {
  return (
    <div className="space-y-1">
      <ListingPageIconRow icon={UserIcon} text={name} />
      <ListingPageIconRow icon={PhoneIcon} text={phone} />
      <ListingPageIconRow icon={EnvelopeIcon} text={email} />
    </div>
  );
}
