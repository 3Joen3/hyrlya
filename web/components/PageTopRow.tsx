interface Props {
  heading: string;
  children?: React.ReactNode;
}

export default function PageTopRow({ heading, children }: Props) {
  return (
    <div className="flex justify-between items-center">
      <h1 className="text-2xl font-bold underline">{heading}</h1>
      <div>{children}</div>
    </div>
  );
}
