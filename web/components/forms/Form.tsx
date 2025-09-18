import PageHeading from "../PageHeading";
import { FieldValues, FormProvider, UseFormReturn } from "react-hook-form";

interface Props<T extends FieldValues> {
  className?: string;
  methods: UseFormReturn<T>;
  onSubmit: (data: T) => void;
  heading: string;
  children: React.ReactNode;
}

export default function Form<T extends FieldValues>({
  className,
  methods,
  onSubmit,
  heading,
  children,
}: Props<T>) {
  const { handleSubmit } = methods;

  return (
    <FormProvider {...methods}>
      <form className={`${className} space-y-6`} onSubmit={handleSubmit(onSubmit)}>
        <PageHeading heading={heading} />
        {children}
      </form>
    </FormProvider>
  );
}
