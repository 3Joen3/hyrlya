import Header from "./Header";
import Link from "next/link";

export default function PublicHeader() {
  return (
    <Header>
      <Link href="/">Logo</Link>
      <Link href="/auth">Hyr ut din bostad</Link>
    </Header>
  );
}
