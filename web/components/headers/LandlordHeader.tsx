"use client";

import Link from "next/link";
import HomeIcon from "../icons/HomeIcon";
import DocumentIcon from "../icons/DocumentIcon";

import { usePathname } from "next/navigation";

export default function HasLandlordHeader() {
  return (
    <header className="grid grid-rows-2 h-28">
      <TopSection />
      <BottomSection />
    </header>
  );
}

function TopSection() {
  return (
    <div className="bg-neutral-700 text-white flex">
      <div className="w-10/12 mx-auto flex items-center">
        <Link className="text-3xl font-bold" href="/">
          hyrlya
        </Link>
      </div>
    </div>
  );
}

function BottomSection() {
  const pathName = usePathname();
  const navLinks = [
    {
      href: "/landlord/listings",
      label: "Annonser",
      icon: <DocumentIcon className="size-6" />,
    },
    {
      href: "/landlord/rental-units",
      label: "Hyresobjekt",
      icon: <HomeIcon className="size-6" />,
    },
  ];

  return (
    <div className="bg-white text-neutral-700">
      <div className="w-10/12 mx-auto h-full flex items-center gap-6">
        {navLinks.map((link) => (
          <BottomNavLink key={link.href} currentPath={pathName} {...link} />
        ))}
      </div>
    </div>
  );
}

interface BottomNavLinkProps {
  href: string;
  label: string;
  icon: React.ReactNode;
  currentPath: string;
}

function BottomNavLink({ href, label, icon, currentPath }: BottomNavLinkProps) {
  const isActive = currentPath.startsWith(href);
  return (
    <Link
      className={`h-full flex items-center gap-2 ${
        isActive ? "border-b border-b-sky-600 font-semibold" : ""
      }`}
      href={href}
    >
      {icon} {label} <p>{isActive}</p>
    </Link>
  );
}
