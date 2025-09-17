import FormField from "./FormField";

import { useFormContext } from "react-hook-form";

interface Props {
  id: string;
  label: string;
  options: { value: string | number; label: string }[];
}

export default function SelectField({ id, label, options }: Props) {
  const { register } = useFormContext();

  return (
    <FormField id={id} label={label}>
      <select
        id={id}
        {...register(id)}
        className="w-full rounded-md border border-neutral-300 bg-white px-3 py-2 
                   text-sm shadow-sm focus:border-sky-600 focus:ring-1 focus:ring-sky-600"
      >
        {options.map((option) => (
          <option key={option.value} value={option.value}>
            {option.label}
          </option>
        ))}
      </select>
    </FormField>
  );
}
