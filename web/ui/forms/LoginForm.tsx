import Form from "@/components/forms/Form";
import FormSection from "@/components/forms/FormSection";
import FormSubmit from "@/components/forms/FormSubmit";
import TextField from "@/components/forms/TextField";

import { login } from "@/lib/actions/auth";
import { LoginData, loginSchema } from "@/lib/schemas/loginSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";

export default function LoginForm() {
  const methods = useForm<LoginData>({
    resolver: zodResolver(loginSchema),
  });

  async function handleSubmit(data: LoginData) {
    await login(data);
  }

  return (
    <Form methods={methods} onSubmit={handleSubmit}>
      <FormSection>
        <TextField id="email" label="Ange e-postadress" />
        <TextField id="password" label="Ange lösenord" />

        <FormSubmit label="Logga in" loadingLabel="Loggar in..." />
      </FormSection>
    </Form>
  );
}
