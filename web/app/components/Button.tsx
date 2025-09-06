interface Props extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: keyof typeof variants;
  children: React.ReactNode;
}

const variants: Record<string, string> = {
  primary: "bg-orange-400 text-white font-bold",
};

export default function Button({ variant = "primary", children }: Props) {
  return (
    <button className={`cursor-pointer ${variants[variant]}`}>
      {children}
    </button>
  );
}
