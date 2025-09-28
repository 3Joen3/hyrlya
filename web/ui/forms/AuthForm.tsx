"use client";

import Block from "@/components/Block";
import Form from "@/components/forms/Form";
import TextField from "@/components/forms/TextField";
import FormSection from "@/components/forms/FormSection";
import FormSubmit from "@/components/forms/FormSubmit";

import { useState } from "react";
import { useForm } from "react-hook-form";
import { AuthData, authSchema } from "@/lib/schemas/authSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { login, register } from "@/lib/actions/auth";

export default function AuthForm() {
  const [isRegisterForm, setIsRegisterForm] = useState(true);

  const methods = useForm<AuthData>({
    resolver: zodResolver(authSchema),
  });

  async function handleSubmit(data: AuthData) {
    if (isRegisterForm) await register(data);
    await login(data);
  }

  return (
    <div>
      <div className="grid grid-cols-2">
        <FormSelectorButton
          label="Logga in"
          isActive={!isRegisterForm}
          onClick={() => setIsRegisterForm(false)}
        />
        <FormSelectorButton
          label="Skapa konto"
          isActive={isRegisterForm}
          onClick={() => setIsRegisterForm(true)}
        />
      </div>
      <Block>
        <Form methods={methods} onSubmit={handleSubmit}>
          <FormSection>
            <TextField id="email" label="Ange e-postadress" />
            <TextField type="password" id="password" label="Ange lösenord" />
            <FormSubmit
              label={isRegisterForm ? "Skapa konto" : "Logga in"}
              loadingLabel={"Laddar..."}
            />
          </FormSection>
        </Form>
      </Block>
    </div>
  );
}

interface FormSelectorButtonProps {
  label: string;
  isActive: boolean;
  onClick: () => void;
}

function FormSelectorButton({ label, isActive, onClick }: FormSelectorButtonProps) {
  return (
    <button
      onClick={onClick}
      type="button"
      className={`${
        isActive ? "btn-color-primary shadow-md" : "text-neutral-600 hover:bg-neutral-50"
      } rounded-t py-2 transition-colors duration-200`}
    >
      {label}
    </button>
  );
}
