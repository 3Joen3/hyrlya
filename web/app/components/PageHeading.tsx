interface Props {
  heading: string;
}

export default function PageHeading({ heading }: Props) {
  return <h1 className="text-xl font-bold underline">{heading}</h1>;
}
