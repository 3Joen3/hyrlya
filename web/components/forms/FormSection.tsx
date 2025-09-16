interface Props {
  children: React.ReactNode;
}

export default function FormSection({ children }: Props) {
  return <div className="space-y-2">{children}</div>;
}
