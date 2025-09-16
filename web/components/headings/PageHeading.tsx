interface Props {
  className: string;
  heading: string;
}

export default function PageHeading({ className, heading }: Props) {
  return <h1 className={`${className} text-2xl font-bold underline`}>{heading}</h1>;
}
