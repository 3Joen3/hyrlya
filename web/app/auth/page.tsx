import Page from "../components/Page";
import Section from "../components/Section";
import AuthForm from "../components/Forms/AuthForm";

export default function page() {
  return (
    <Page>
      <Section className="w-full lg:w-2/5 justify-self-center space-y-4 mt-10">
        <AuthForm />
      </Section>
    </Page>
  );
}
