import Link from "next/link";
import NavLink from "../NavLink";

export default function PublicHeader() {
  return (
    <header className="h-14 bg-neutral-700 text-white flex">
      <div className="w-10/12 mx-auto flex items-center justify-between">
        <Link className="text-3xl font-bold" href={"/"}>
          hyrlya
        </Link>
        <NavLink href="/auth">Hyr ut din bostad</NavLink>
      </div>
    </header>
  );
}
