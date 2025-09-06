"use client";

import Form from "./Form";
import TextField from "./TextField";
import Submit from "./Submit";

import { useForm } from "react-hook-form";
import { SignUpData, signUpSchema } from "@/lib/schemas/signUpSchema";
import { zodResolver } from "@hookform/resolvers/zod";

export default function AuthForm() {
  return (
    <>
      <SignUpForm />
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
      <TextField id="firstName" label="Efternamn" />
      <TextField className="col-span-2" id="email" label="Ange e-postadress" />
      <TextField className="col-span-2" id="password" label="Ange lösenord" />
      <Button type="submit">Registrera</Button>
    </Form>
  );
}
