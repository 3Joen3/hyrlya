interface Props {
  children: React.ReactNode;
}

export default function Header({ children }: Props) {
  return (
    <header className="bg-sky-600">
      <div className="w-11/12 mx-auto py-4">{children}</div>
    </header>
  );
}
