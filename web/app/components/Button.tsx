interface Props extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: keyof typeof variants;
  className?: string;
  children: React.ReactNode;
}

const variants = {
  primary: "bg-orange-400 text-white font-bold",
  ghost: "bg-transparent text-orange-400 hover:bg-orange-50 font-semibold",
} as const;

export default function Button({
  variant = "primary",
  className,
  children,
  type = "button",
  ...rest
}: Props) {
  const classNames = variants[variant] + " " + className;

  return (
    <button className={`cursor-pointer ${classNames}`} {...rest}>
      {children}
    </button>
  );
}
