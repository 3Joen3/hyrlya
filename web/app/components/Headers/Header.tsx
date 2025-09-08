interface Props {
  children: React.ReactNode;
}

export default function Header({ children }: Props) {
  return <header className="w-11/12 mx-auto bg-sky-600">{children}</header>;
}
