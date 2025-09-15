import { useFormContext } from "react-hook-form";
import { ErrorMessage } from "@hookform/error-message";

interface Props {
  className?: string;
  label: string;
  id: string;
}

export default function TextField({ className, label, id }: Props) {
  const { register } = useFormContext();

  return (
    <div className={`${className} flex flex-col gap-1`}>
      <label className="text-lg" htmlFor={id}>
        {label}
      </label>
      <input
        className="rounded border border-neutral-300 px-2 py-1.5 placeholder:text-neutral-400 focus:outline-none focus:border-sky-600 focus:ring-1 focus:ring-sky-600"
        type="text"
        id={id}
        {...register(id)}
      />
      <ErrorMessage name={id} />
    </div>
  );
}
