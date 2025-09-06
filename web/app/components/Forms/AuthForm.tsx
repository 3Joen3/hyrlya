"use client";

import Button from "../Button";
import Form from "./Form";
import TextField from "./TextField";

import { useState } from "react";
import { useForm } from "react-hook-form";
import { SignUpData, signUpSchema } from "@/lib/schemas/signUpSchema";
import { zodResolver } from "@hookform/resolvers/zod";

export default function AuthForm() {
  const [showSignUpForm, setshowSignUpForm] = useState(true);

  return (
    <>
      <div>
        <Button
          onClick={() => setshowSignUpForm(false)}
          variant={showSignUpForm ? undefined : "ghost"}
        >
          Logga in
        </Button>
        <Button
          onClick={() => setshowSignUpForm(true)}
          variant={showSignUpForm ? "ghost" : undefined}
        >
          Registrera konto
        </Button>
      </div>
      {showSignUpForm ? <SignUpForm /> : <LoginForm />}
    </>
  );
}

function SignUpForm() {
  const methods = useForm<SignUpData>({
    resolver: zodResolver(signUpSchema),
  });

  function handleSubmit(data: SignUpData) {
    console.log(data);
  }

  return (
    <Form
      className="grid grid-cols-2 gap-4"
      onSubmit={handleSubmit}
      methods={methods}
    >
      <TextField id="firstName" label="Förnamn" />
      <TextField id="lastName" label="Efternamn" />
      <TextField className="col-span-2" id="email" label="Ange e-postadress" />
      <TextField className="col-span-2" id="password" label="Ange lösenord" />
      <Button type="submit">Registrera</Button>
    </Form>
  );
}

function LoginForm() {
  return <div></div>;
}
