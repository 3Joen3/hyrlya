"use client";

import Button from "../Button";
import Form from "./Form";
import TextField from "./TextField";

import { post } from "@/lib/api/utils";
import { useState } from "react";
import { useForm } from "react-hook-form";
import { RegisterData, registerSchema } from "@/lib/schemas/registerSchema";
import { zodResolver } from "@hookform/resolvers/zod";

export default function AuthForm() {
  const [showRegisterForm, setShowRegisterForm] = useState(true);

  return (
    <>
      <div className="flex">
        <Button
          className="flex-1"
          onClick={() => setShowRegisterForm(false)}
          variant={showRegisterForm ? undefined : "ghost"}
        >
          Logga in
        </Button>
        <Button
          className="flex-1"
          onClick={() => setShowRegisterForm(true)}
          variant={showRegisterForm ? "ghost" : undefined}
        >
          Registrera konto
        </Button>
      </div>
      {showRegisterForm ? <RegisterForm /> : <LoginForm />}
    </>
  );
}

function RegisterForm() {
  const methods = useForm<RegisterData>({
    resolver: zodResolver(registerSchema),
  });

  async function handleSubmit(data: RegisterData) {
  }

  return (
    <Form
      className="grid grid-cols-2 gap-4"
      onSubmit={handleSubmit}
      methods={methods}
    >
      <TextField className="col-span-2" id="email" label="Ange e-postadress" />
      <TextField className="col-span-2" id="password" label="Ange lösenord" />
      <Button className="col-start-2" type="submit">
        Registrera
      </Button>
    </Form>
  );
}

function LoginForm() {
  return <div></div>;
}
