import Header from "../components/Header";
import NavLink from "../components/NavLink";

export default function PublicLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <>
      <Header className="justify-between" logoHref="/">
        <NavLink href="/auth">Hyr ut din bostad</NavLink>
      </Header>
      {children}
    </>
  );
}
