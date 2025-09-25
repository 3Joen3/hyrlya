interface Props {
  className?: string;
  children: React.ReactNode;
}

export default function Page({ className, children }: Props) {
  return <main className={`w-10/12 mx-auto ${className}`}>{children}</main>;
}
