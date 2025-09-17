import Dropzone from "react-dropzone";
import ImageIcon from "../icons/ImageIcon";

interface Props {
  onDrop: (acceptedFiles: File[]) => void;
}

export default function ImageUploaderDropZone({ onDrop }: Props) {
  return (
    <Dropzone onDrop={onDrop}>
      {({ getRootProps, getInputProps, isDragActive }) => (
        <div
          {...getRootProps()}
          className="cursor-pointer flex flex-col items-center justify-center bg-neutral-100 border border-dashed border-neutral-300 rounded"
        >
          <input {...getInputProps()} />
          {isDragActive ? (
            <p>Släpp filerna här …</p>
          ) : (
            <>
              <ImageIcon className="size-15" />
              <p>Släpp filer här, eller klicka för att ladda upp</p>
            </>
          )}
        </div>
      )}
    </Dropzone>
  );
}
