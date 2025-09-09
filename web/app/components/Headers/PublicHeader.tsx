import Header from "./Header";
import Link from "next/link";

export default function PublicHeader() {
  return (
    <Header className="justify-between" logoHref="/">
      <Link className="underline font-semibold" href="/auth">Hyr ut din bostad</Link>
    </Header>
  );
}
