"use client";

import { useFormContext } from "react-hook-form";
import ImageUploaderDropZone from "./ImageUploaderDropZone";
import ImageUploaderGallery from "./ImageUploaderGallery";

import { useEdgeStore } from "@/lib/edgestore";
import { useEffect, useState } from "react";

interface Props {
  id: string;
  currentImageUrls?: string[];
}

export default function ImageUploader({ id, currentImageUrls }: Props) {
  const { edgestore } = useEdgeStore();
  const [uploadedImages, setUploadedImages] = useState<string[]>(currentImageUrls ?? []);
  const { setValue } = useFormContext();

  async function handleDroppedFiles(acceptedFiles: File[]) {
    const responses = await Promise.all(
      acceptedFiles.map((file) =>
        edgestore.publicImages.upload({
          file,
          input: { type: "listing" },
        })
      )
    );

    const urls = responses.map((res) => res.url);
    setUploadedImages((prev) => [...prev, ...urls]);
  }

  useEffect(() => {
    setValue(id, uploadedImages);
  }, [uploadedImages, id, setValue]);

  return (
    <div>
      <ImageUploaderDropZone onDrop={handleDroppedFiles} />
      <ImageUploaderGallery imageUrls={uploadedImages} />
    </div>
  );
}
