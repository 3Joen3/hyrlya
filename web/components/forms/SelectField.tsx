import FormField from "./FormField";

import { useFormContext } from "react-hook-form";

interface Props {
  id: string;
  label: string;
  options: { value: string; label: string }[];
}

export default function SelectField({ id, label, options }: Props) {
  const { register } = useFormContext();

  return (
    <FormField id={id} label={label}>
      <select
        id={id}
        {...register(id)}
        className="rounded border border-neutral-300 px-2 py-1.5 
             focus:outline-none focus:border-sky-600 focus:ring-1 focus:ring-sky-600"
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
