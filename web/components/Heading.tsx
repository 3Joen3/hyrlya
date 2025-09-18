interface Props {
  heading: string;
}

export default function Heading({ heading }: Props) {
  return <h1 className="text-2xl font-bold underline">{heading}</h1>;
}
