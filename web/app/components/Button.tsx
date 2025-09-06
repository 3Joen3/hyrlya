interface Props extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: keyof typeof variants;
  children: React.ReactNode;
}

const variants = {
  primary: "bg-orange-400 text-white font-bold",
  ghost: "bg-transparent text-orange-400 hover:bg-orange-50 font-semibold",
} as const;

export default function Button({ variant = "primary", children }: Props) {
  return (
    <button className={`cursor-pointer ${variants[variant]}`}>
      {children}
    </button>
  );
}
