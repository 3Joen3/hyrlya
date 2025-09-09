"use client";

import Button from "../Button";
import Block from "../Block";
import Form from "./Form";
import TextField from "./TextField";

import { useState } from "react";
import { useForm } from "react-hook-form";
import { RegisterData, registerSchema } from "@/lib/schemas/registerSchema";
import { zodResolver } from "@hookform/resolvers/zod";
import { login, register } from "@/app/(public)/auth/actions";
import { LoginData, loginSchema } from "@/lib/schemas/loginSchema";

interface Props {
  className?: string;
}

export default function AuthForm({ className }: Props) {
  const [showRegisterForm, setShowRegisterForm] = useState(true);

  return (
    <div className={className}>
      <div className="grid grid-cols-2">
        <Button
          color={showRegisterForm ? "ghost" : "secondary"}
          useHoverEffects={showRegisterForm ? true : false}
          variant="none"
          className={`rounded-t py-2 transition-colors duration-200 ${
            showRegisterForm ? "" : "font-semibold shadow-md"
          }`}
          onClick={() => setShowRegisterForm(false)}
        >
          Logga in
        </Button>
        <Button
          color={showRegisterForm ? "secondary" : "ghost"}
          useHoverEffects={showRegisterForm ? false : true}
          variant="none"
          className={`rounded-t py-2 transition-colors duration-200 ${
            showRegisterForm ? "font-semibold" : ""
          }`}
          onClick={() => setShowRegisterForm(true)}
        >
          Skapa konto
        </Button>
      </div>
      <Block>{showRegisterForm ? <RegisterForm /> : <LoginForm />}</Block>
    </div>
  );
}

function RegisterForm() {
  const methods = useForm<RegisterData>({
    resolver: zodResolver(registerSchema),
  });

  async function handleSubmit(data: RegisterData) {
    await register(data);
    await login(data);
  }

  return (
    <Form className="space-y-4" onSubmit={handleSubmit} methods={methods}>
      <TextField id="email" label="Ange e-postadress" />
      <TextField id="password" label="Ange lösenord" />
      <Button className="w-full" type="submit">
        Skapa konto
      </Button>
    </Form>
  );
}

function LoginForm() {
  const methods = useForm<LoginData>({
    resolver: zodResolver(loginSchema),
  });

  async function handleSubmit(data: LoginData) {
    await login(data);
  }

  return (
    <Form className="space-y-4" methods={methods} onSubmit={handleSubmit}>
      <TextField id="email" label="Ange e-postadress" />
      <TextField id="password" label="Ange lösenord" />
      <Button className="w-full" type="submit">
        Logga in
      </Button>
    </Form>
  );
}
