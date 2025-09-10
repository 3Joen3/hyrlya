import Link from "next/link";

interface Props {
  href: string;
  children: React.ReactNode;
  variant?: keyof typeof variants;
  color?: keyof typeof colors;
  className?: string;
}

const variants = {
  primary: "underline font-semibold",
  buttonPrimary: "rounded px-3 py-2 font-semibold",
  none: "",
} as const;

const colors = {
  primary: "",
  buttonPrimary: "bg-neutral-700 text-white hover:bg-neutral-800",
  buttonSecondary: "bg-sky-600 text-white hover:bg-sky-700",
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
