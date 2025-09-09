import Link from "next/link";

interface Props {
  href: string;
  children: React.ReactNode;
  variant?: keyof typeof variants;
  color?: keyof typeof colors;
  className?: string;
}

const variants = {
  primary: "rounded px-3 py-2 font-semibold",
  none: "",
} as const;

const colors = {
  primary: "bg-neutral-700 hover:bg-neutral-800 text-white",
  secondary: "bg-sky-600 hover:bg-sky-700 text-white",
} as const;

export default function NavLink({
  href,
  children,
  variant = "primary",
  color = "primary",
  className,
}: Props) {
  const classNames = [variants[variant], colors[color], className].join(" ");

  return (
    <Link className={classNames} href={href}>
      {children}
    </Link>
  );
}
