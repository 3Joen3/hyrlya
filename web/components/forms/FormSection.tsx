interface Props {
  heading: string;
  children: React.ReactNode;
}

export default function FormSection({ heading, children }: Props) {
  return <div className="space-y-2">
    
    {children}</div>;
}
