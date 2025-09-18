interface Props {
  className?: string;
  children: React.ReactNode;
}

export default function Page({ className, children }: Props) {
  return <main className={`w-11/12 mx-auto flex-1 space-y-6 ${className}`}>{children}</main>;
}
