import { useFormContext } from "react-hook-form";

interface Props {
  label: string;
  loadingLabel: string;
  className?: string;
}

export default function FormSubmit({
  label,
  loadingLabel,
  className = "btn-primary btn-color-primary",
}: Props) {
  const {
    formState: { isSubmitting },
  } = useFormContext();

  return (
    <button type="submit" className={className}>
      {isSubmitting ? loadingLabel : label}
    </button>
  );
}
