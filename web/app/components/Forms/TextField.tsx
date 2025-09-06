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
    <div className={`${className} space-y-1`}>
      <label className="block text-sm font-medium text-gray-700" htmlFor={id}>
        {label}
      </label>
      <input
        className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500 sm:text-sm"
        type="text"
        id={id}
        {...register(id)}
      />
      <ErrorMessage name={id} />
    </div>
  );
}
