"use client";

import Block from "@/components/Block";
import LoginForm from "./LoginForm";
import RegisterForm from "./RegisterForm";

import { useState } from "react";

export default function AuthForm() {
  const [isRegisterForm, setIsRegisterForm] = useState(true);

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
      <Block>{isRegisterForm ? <RegisterForm /> : <LoginForm />}</Block>
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
        isActive
          ? "btn-color-primary-no-hover shadow-md"
          : "text-neutral-600 hover:bg-neutral-50 cursor-pointer"
      } rounded-t py-2 transition-colors duration-200`}
    >
      {label}
    </button>
  );
}
