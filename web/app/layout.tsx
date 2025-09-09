import "./globals.css";

import { Montserrat } from "next/font/google";
import type { Metadata } from "next";

const montserrat = Montserrat({
  subsets: ["latin"],
  display: "swap",
});

export const metadata: Metadata = {
  title: "HyrLya – Hitta och hyr bostäder enkelt",
  description:
    "Utforska lediga lägenheter och hyr direkt via HyrLya. Enkelt för både hyresvärdar och hyresgäster.",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={`${montserrat.className} bg-neutral-100`}>{children}</body>
    </html>
  );
}
