import Link from "next/link";

interface Props {
  href: string;
  children: React.ReactNode;
  variant?: keyof typeof variants;
  color?: keyof typeof colors;
  useHoverEffects?: boolean;
  className?: string;
}

const variants = {
  primary: "rounded px-3 py-2 font-semibold",
  none: "",
} as const;

const colors = {
  primary: { base: "bg-neutral-700 text-white", hover: "hover:bg-neutral-800" },
  secondary: { base: "bg-sky-600 text-white", hover: "hover:bg-sky-700" },
} as const;

export default function NavLink({
  href,
  children,
  variant = "primary",
  color = "primary",
  useHoverEffects = true,
  className,
}: Props) {
  const { base, hover } = colors[color];

  const classNames = [
    variants[variant],
    base,
    useHoverEffects && hover,
    className,
  ]
    .filter(Boolean)
    .join(" ");

  return (
    <Link className={classNames} href={href}>
      {children}
    </Link>
  );
}
