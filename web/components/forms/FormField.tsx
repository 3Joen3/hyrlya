interface Props {
  id: string;
  label: string;
  children: React.ReactNode;
}

export default function FormField({ id, label, children }: Props) {
  return (
    <div className="flex flex-col gap-1">
      <label htmlFor={id} className="text-lg">
        {label}
      </label>
      {children}
    </div>
  );
}
