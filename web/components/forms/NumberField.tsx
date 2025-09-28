import { useFormContext } from "react-hook-form";

interface Props {
  id: string;
  label: string;
}

export default function NumberField({ id, label }: Props) {
  const {
    register,
    formState: { errors },
  } = useFormContext();

  const error = errors[id]?.message as string;

  return (
    <div className="flex flex-col space-y-1">
      <label htmlFor={id} className="text-lg">
        {label}
      </label>
      <input
        id={id}
        {...register(id, { valueAsNumber: true })}
        type="number"
        className={`rounded border px-2 py-1.5 focus:outline-none focus:ring-1 ${
          error
            ? "border-red-500 focus:border-red-500 focus:ring-red-500"
            : "border-neutral-300   focus:border-sky-600  focus:ring-sky-600"
        }`}
      />
      {error && <p className="text-red-600">{error}</p>}
    </div>
  );
}
