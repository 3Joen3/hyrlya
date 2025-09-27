"use client";

import useEmblaCarousel from "embla-carousel-react";

export default function ImageCarousel() {
  const [emblaRef] = useEmblaCarousel();

  return (
    <div className="overflow-hidden" ref={emblaRef}>
      <div className="flex">
        <div className="flex-none basis-full min-w-0">Slide 1</div>
        <div className="flex-none basis-full min-w-0">Slide 2</div>
        <div className="flex-none basis-full min-w-0">Slide 3</div>
      </div>
    </div>
  );
}
