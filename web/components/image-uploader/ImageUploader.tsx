"use client";

import Image from "next/image";
import { ArrowUpTrayIcon } from "@heroicons/react/24/outline";

import { useCallback } from "react";
import { useDropzone } from "react-dropzone";
import { useEdgeStore } from "@/lib/edgestore";
import { useFormContext } from "react-hook-form";

interface Props {
  id: string;
}

export default function ImageUploader({ id }: Props) {
  const { edgestore } = useEdgeStore();
  const {
    setValue,
    watch,
    formState: { errors },
  } = useFormContext();

  const error = errors[id]?.message as string;

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
        <ButtonContainer open={open} error={error} />
      </div>
      {error && <p className="text-red-600 mt-1">{error}</p>}
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

function ButtonContainer({ open, error }: { open: () => void; error?: string }) {
  return (
    <Container className="hover:bg-neutral-300" error={error}>
      <button
        className="cursor-pointer size-full flex flex-col items-center justify-center"
        onClick={open}
        type="button"
      >
        <ArrowUpTrayIcon className="size-10" />
      </button>
    </Container>
  );
}

function Container({
  className,
  children,
  error,
}: {
  className: string;
  children: React.ReactNode;
  error?: string;
}) {
  return (
    <div
      className={`${className} ${
        error ? "border-red-500" : "border-neutral-300"
      } bg-neutral-100 aspect-square rounded border border-dashed`}
    >
      {children}
    </div>
  );
}
