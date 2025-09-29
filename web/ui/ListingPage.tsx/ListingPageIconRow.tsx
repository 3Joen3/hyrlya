interface Props {
  icon: React.ComponentType<React.SVGProps<SVGSVGElement>>;
  text: string;
}

export default function ListingPageIconRow({ icon, text }: Props) {
  const Icon = icon;
  return (
    <div className="flex items-center gap-2">
      <Icon className="size-5" />
      <p>{text}</p>
    </div>
  );
}
