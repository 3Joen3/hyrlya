import NavLink from "../NavLink";
import Header from "./Header";

export default function PublicHeader() {
  return (
    <Header className="justify-between" logoHref="/">
      <NavLink href="/auth">Hyr ut din bostad</NavLink>
    </Header>
  );
}
