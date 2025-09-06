interface Props {
  label: string;
}

export default function Submit({ label }: Props) {
  return (
    <button
      className=" cursor-pointer text-white bg-orange-400 font-bold"
      type="submit"
    >
      {label}
    </button>
  );
}
