import Link from "next/link";

export default function PublicHeader() {
  return (
    <header className="h-14 bg-neutral-700 text-white flex">
      <div className="w-11/12 mx-auto md:w-10/12 flex items-center justify-between">
        <Link className="text-3xl font-bold" href={"/"}>
          hyrlya
        </Link>
        <Link className="btn-primary-slim btn-color-primary" href="/auth">Hyr ut din bostad</Link>
      </div>
    </header>
  );
}
