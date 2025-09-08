import PublicHeader from "../components/Headers/PublicHeader";

export default function PublicLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <>
      <PublicHeader />
      {children}
    </>
  );
}
