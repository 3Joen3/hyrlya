import FormField from "./FormField";

import { useFormContext } from "react-hook-form";

interface Props {
  id: string;
  label: string;
}

export default function TextField({ id, label }: Props) {
  const { register } = useFormContext();

  return (
    <FormField id={id} label={label}>
      <input
        className="rounded border border-neutral-300 px-2 py-1.5 focus:outline-none focus:border-sky-600 focus:ring-1 focus:ring-sky-600"
        type="text"
        id={id}
        {...register(id)}
      />
    </FormField>
  );
}
