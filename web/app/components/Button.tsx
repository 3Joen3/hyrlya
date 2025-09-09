interface Props extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: keyof typeof variants;
  color?: keyof typeof colors;
  className?: string;
  children: React.ReactNode;
}

const variants = {
  primary: "rounded py-2 font-semibold",
  none: "",
} as const;

const colors = {
  primary: "bg-neutral-700 hover:bg-neutral-800 text-white",
  secondary: "bg-sky-600 hover:bg-sky-700 text-white",
  ghost: "text-neutral-400 hover:bg-neutral-50",
} as const;

export default function Button({
  variant = "primary",
  color = "primary",
  className,
  children,
  type = "button",
  ...rest
}: Props) {
  const classNames = variants[variant] + " " + colors[color] + " " + className;

  return (
    <button type={type} className={`cursor-pointer ${classNames}`} {...rest}>
      {children}
    </button>
  );
}
