import { FieldValues, FormProvider, UseFormReturn } from "react-hook-form";

interface Props<T extends FieldValues> {
  className?: string;
  methods: UseFormReturn<T>;
  onSubmit: (data: T) => void;
  children: React.ReactNode;
}

export default function Form<T extends FieldValues>({
  className,
  methods,
  onSubmit,
  children,
}: Props<T>) {
  const { handleSubmit } = methods;

  return (
    <FormProvider {...methods}>
      <form className={`${className}`} onSubmit={handleSubmit(onSubmit)}>
        {children}
      </form>
    </FormProvider>
  );
}
