interface Props {
  heading?: string;
  children: React.ReactNode;
}

export default function FormSection({ heading, children }: Props) {
  return (
    <div className="space-y-2">
      {heading && <h2 className="text-xl font-semibold">{heading}</h2>}
      {children}
    </div>
  );
}
