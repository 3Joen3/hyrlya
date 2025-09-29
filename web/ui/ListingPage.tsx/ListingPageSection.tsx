interface Props {
  heading: string;
  className?: string;
  children: React.ReactNode;
  spaceChildren?: boolean;
}

export default function ListingPageSection({
  heading,
  className,
  children,
  spaceChildren = false,
}: Props) {
  return (
    <div className="space-y-3">
      <h2 className="text-xl font-semibold">{heading}</h2>
      <div className={`${className} ${spaceChildren ? "space-y-1" : ""}`}>{children}</div>
    </div>
  );
}
