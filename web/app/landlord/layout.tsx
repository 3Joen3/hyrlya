import LandlordHeader from "../components/Headers/LandlordHeader";

export default function HostLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <>
      <LandlordHeader />
      {children}
    </>
  );
}
