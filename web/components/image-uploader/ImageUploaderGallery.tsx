"use client";

import Image from "next/image";

interface Props {
  imageUrls: string[];
}

export default function ImageUploaderGallery({ imageUrls }: Props) {
  return (
    <div className="grid grid-cols-4 gap-4">
      {imageUrls.map((url, index) => {
        const key = `Uploaded image - ${index + 1}`;
        return <ImageContainer key={key} url={url} altText={key} />;
      })}
    </div>
  );
}

function ImageContainer({ url, altText }: { url: string; altText: string }) {
  return (
    <div className="relative aspect-square rounded overflow-hidden">
      <Image className="object-cover" src={url} alt={altText} fill />
    </div>
  );
}
