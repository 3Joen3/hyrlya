import Image from "next/image";
import UserIcon from "../icons/UserIcon";

interface Props {
  className: string;
  imageUrl?: string;
}

export default function ProfileImage({ className, imageUrl }: Props) {
  return (
    <div
      className={`${className} aspect-square rounded-full overflow-hidden bg-neutral-300 flex items-center justify-center`}
    >
      {imageUrl ? <UserImage imageUrl={imageUrl} /> : <Placeholder />}
    </div>
  );
}

function UserImage({ imageUrl }: { imageUrl: string }) {
  return (
    <div className="relative w-full h-full">
      <Image className="object-cover" src={imageUrl} alt="Something" fill />
      <p></p>
    </div>
  );
}

function Placeholder() {
  return <UserIcon className="w-1/2" />;
}
