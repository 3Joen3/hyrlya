"use client";

import Button from "@/components/Button";
import Block from "@/components/Block";
import Form from "@/components/forms/Form";
import TextField from "@/components/forms/TextField";

import { useState } from "react";
import { useForm } from "react-hook-form";
import { AuthData, authSchema } from "@/lib/schemas/authSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { login, register } from "@/lib/actions/auth";
import FormSection from "@/components/forms/FormSection";

export default function AuthForm() {
  const [isRegisterForm, setIsRegisterForm] = useState(true);

  const methods = useForm<AuthData>({
    resolver: zodResolver(authSchema),
  });

  const { isSubmitting } = methods.formState;

  async function handleSubmit(data: AuthData) {
    if (isRegisterForm) await register(data);
    await login(data);
  }

  return (
    <>
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
            <TextField id="password" label="Ange lösenord" />
            <Button className="w-full" type="submit">
              {isSubmitting ? "Laddar..." : isRegisterForm ? "Skapa konto" : "Logga in"}
            </Button>
          </FormSection>
        </Form>
      </Block>
    </>
  );
}

interface FormSelectorButtonProps {
  label: string;
  isActive: boolean;
  onClick: () => void;
}

function FormSelectorButton({ label, isActive, onClick }: FormSelectorButtonProps) {
  return (
    <Button
      color={isActive ? "secondary" : "ghost"}
      useHoverEffects={isActive}
      variant="none"
      className={`rounded-t py-2 transition-colors duration-200 ${
        isActive ? "font-semibold shadow-md" : ""
      }`}
      onClick={onClick}
    >
      {label}
    </Button>
  );
}
