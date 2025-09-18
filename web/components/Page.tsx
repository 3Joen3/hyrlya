interface Props {
  className?: string;
  heading?: string;
  children: React.ReactNode;
}

export default function Page({ className, heading, children }: Props) {
  return (
    <main className={`w-11/12 mx-auto flex-1 space-y-6 ${className}`}>
      {heading && <h1 className="text-2xl font-bold underline">{heading}</h1>}
      {children}
    </main>
  );
}
