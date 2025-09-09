interface Props extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: keyof typeof variants;
  color?: keyof typeof colors;
  useHoverEffects?: boolean;
  className?: string;
  children: React.ReactNode;
}

const variants = {
  primary: "rounded py-2 font-semibold",
  none: "",
} as const;

const colors = {
  primary: { base: "bg-neutral-700 text-white", hover: "hover:bg-neutral-800" },
  secondary: { base: "bg-sky-600 text-white", hover: "hover:bg-sky-700" },
  ghost: { base: "text-neutral-600", hover: "hover:bg-neutral-50" },
} as const;

export default function Button({
  variant = "primary",
  color = "primary",
  useHoverEffects = true,
  className,
  children,
  type = "button",
  ...rest
}: Props) {
  const { base, hover } = colors[color];

  const classNames = [
    "cursor-pointer",
    variants[variant],
    base,
    useHoverEffects && hover,
    className,
  ]
    .filter(Boolean)
    .join(" ");

  return (
    <button type={type} className={`cursor-pointer ${classNames}`} {...rest}>
      {children}
    </button>
  );
}
