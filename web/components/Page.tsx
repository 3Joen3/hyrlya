interface Props {
  className?: string;
  children: React.ReactNode;
}

export default function Page({ className, children }: Props) {
  return <main className={`w-11/12 mx-auto md:w-10/12 ${className}`}>{children}</main>;
}
