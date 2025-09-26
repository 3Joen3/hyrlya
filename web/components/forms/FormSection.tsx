interface Props {
  heading?: string;
  children: React.ReactNode;
}

export default function FormSection({ heading, children }: Props) {
  if (heading) {
    return <WithHeading heading={heading}>{children}</WithHeading>;
  }

  return <div className="space-y-4">{children}</div>;
}

function WithHeading({ heading, children }: { heading: string; children: React.ReactNode }) {
  return (
    <div className="space-y-6">
      <h2 className="text-xl font-semibold">{heading}</h2>
      <div className="space-y-4">{children}</div>
    </div>
  );
}
