import { useFormContext } from "react-hook-form";

interface Props {
  label: string;
  loadingLabel: string;
}

export default function FormSubmit({ label, loadingLabel }: Props) {
  const {
    formState: { isSubmitting },
  } = useFormContext();

  return (
    <button type="submit" className="btn-primary btn-color-primary">
      {isSubmitting ? loadingLabel : label}
    </button>
  );
}
