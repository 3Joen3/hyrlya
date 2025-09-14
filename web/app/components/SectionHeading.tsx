interface Props {
  heading: string;
}

export default function SectionHeading({ heading }: Props) {
  return <h2 className="text-lg font-semibold">{heading}</h2>;
}
