import { useCallback } from "react";
import { useDropzone } from "react-dropzone";

interface Props {
  className: string;
  handleFiles: (files: File[]) => void;
  children: React.ReactNode;
}

export default function DropZone({ className, handleFiles, children }: Props) {
  const onDrop = useCallback(
    (acceptedFiles: File[]) => {
      handleFiles(acceptedFiles);
    },
    [handleFiles]
  );

  const { getRootProps, getInputProps } = useDropzone({
    onDrop,
  });

  return (
    <div {...getRootProps()} className={className}>
      <input {...getInputProps()} />
      {children}
    </div>
  );
}
