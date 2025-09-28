import Form from "@/components/forms/Form";
import FormSection from "@/components/forms/FormSection";
import FormSubmit from "@/components/forms/FormSubmit";
import TextField from "@/components/forms/TextField";

import { register } from "@/lib/actions/auth";
import { RegisterData, registerSchema } from "@/lib/schemas/registerSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";

export default function RegisterForm() {
  const methods = useForm<RegisterData>({
    resolver: zodResolver(registerSchema),
  });

  async function handleSubmit(data: RegisterData) {
    await register(data);
  }

  return (
    <Form methods={methods} onSubmit={handleSubmit}>
      <FormSection>
        <TextField id="email" label="Ange e-postadress" />
        <TextField type="password" id="password" label="Ange lösenord" />

        <FormSubmit label="Skapa konto" loadingLabel="Skapar konto..." />
      </FormSection>
    </Form>
  );
}
