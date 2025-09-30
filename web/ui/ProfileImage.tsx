import Image from "next/image";

import { Image as ImageType } from "@/types/Common";
import { UserIcon } from "@heroicons/react/24/outline";

interface Props {
  image?: ImageType;
}

export default function ProfileImage({ image }: Props) {
  if (image) return <Image src={image.url} alt={image.altText} width={120} height={120} />;
  return <UserIcon className="w-[120px] h-[120px]" />;
}
