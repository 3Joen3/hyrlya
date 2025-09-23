interface Props {
  heading?: string;
  className: string;
  children: React.ReactNode;
}

export default function Page({ heading, className, children }: Props) {
  return (
    <main className={`w-11/12 mx-auto ${heading ? "space-y-6" : ""}`}>
      {heading && <h1 className="text-2xl font-bold underline">{heading}</h1>}
      <div className={className}>{children}</div>
    </main>
  );
}
