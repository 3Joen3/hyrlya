import Link from "next/link";

interface Props {
  className: string;
  children: React.ReactNode;
  logoHref: string;
}

export default function Header({ className, children, logoHref }: Props) {
  return (
    <header className={`bg-white shadow-md`}>
      <div className={`${className} w-11/12 mx-auto py-4 flex items-center`}>
        <Link className="my-auto text-3xl font-bold" href={logoHref}>
          hyrlya
        </Link>
        {children}
      </div>
    </header>
  );
}
