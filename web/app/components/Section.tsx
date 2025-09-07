interface Props {
  className?: string;
  children: React.ReactNode;
}

export default function Section({ className, children }: Props) {
  return (
    <div className={`${className} p-4 bg-white shadow`}>
      {children}
    </div>
  );
}
