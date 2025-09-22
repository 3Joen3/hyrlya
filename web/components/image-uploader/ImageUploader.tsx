"use client";

import Image from "next/image";
import UploadIcon from "../icons/UploadIcon";

import { useCallback } from "react";
import { useDropzone } from "react-dropzone";
import { useEdgeStore } from "@/lib/edgestore";
import { useFormContext } from "react-hook-form";

interface Props {
  id: string;
}

export default function ImageUploader({ id }: Props) {
  const { edgestore } = useEdgeStore();
  const { setValue, watch } = useFormContext();

  const uploadedImages = (watch(id) as string[]) ?? [];

  const onDrop = useCallback(
    async (acceptedFiles: File[]) => {
      const responses = await Promise.all(
        acceptedFiles.map((file) =>
          edgestore.publicImages.upload({
            file,
            input: { type: "listing" },
          })
        )
      );

      const urls = responses.map((res) => res.url);
      setValue(id, [...uploadedImages, ...urls], { shouldValidate: true });
    },
    [uploadedImages]
  );
  const { getRootProps, getInputProps, isDragActive, open } = useDropzone({
    onDrop,
    noClick: true,
  });

  return (
    <div className="relative" {...getRootProps()}>
      <input {...getInputProps()} />
      {isDragActive && <WhenDragActive />}
      <div className="grid grid-cols-4 gap-2">
        {uploadedImages.map((img, index) => (
          <ImageContainer key={index} imageUrl={img} />
        ))}
        <ButtonContainer open={open} />
      </div>
    </div>
  );
}

function WhenDragActive() {
  return (
    <div className="absolute inset-0 z-20 flex flex-col justify-center items-center rounded border border-dashed border-neutral-300 bg-neutral-100">
      <p>Släpp filerna här...</p>
    </div>
  );
}

function ImageContainer({ imageUrl }: { imageUrl: string }) {
  return (
    <Container className="relative overflow-hidden">
      <Image draggable={false} className="object-contain" src={imageUrl} alt="" fill />
    </Container>
  );
}

function ButtonContainer({ open }: { open: () => void }) {
  return (
    <Container className="hover:bg-neutral-300">
      <button
        className="cursor-pointer size-full flex flex-col items-center justify-center"
        onClick={open}
        type="button"
      >
        <UploadIcon className="size-10" />
      </button>
    </Container>
  );
}

function Container({ className, children }: { className: string; children: React.ReactNode }) {
  return (
    <div
      className={`${className} aspect-square rounded border border-dashed bg-neutral-100 border-neutral-300`}
    >
      {children}
    </div>
  );
}
