"use client";

import useEmblaCarousel from "embla-carousel-react";
import Image from "next/image";

import { Image as ImageType } from "@/types/Common";

interface Props {
  className?: string;
  images: ImageType[];
}

export default function ImageCarousel({ className, images }: Props) {
  const [emblaRef] = useEmblaCarousel();

  return (
    <div className={`${className} overflow-hidden`} ref={emblaRef}>
      <div className="flex">
        {images.map((img) => (
          <div key={img.url} className="flex-none basis-full relative aspect-square">
            <Image fill src={img.url} alt={img.altText} />
          </div>
        ))}
      </div>
    </div>
  );
}
