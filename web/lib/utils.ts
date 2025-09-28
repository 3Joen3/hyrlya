export function TranslateRentalUnitType(englishVersion: string) {
  if (englishVersion === "Room") return "Rum";
  if (englishVersion === "Apartment") return "Lägenhet";
  return "Hus";
}

export function TranslateRentalPriceChargeInterval(englishVersion: string) {
  if (englishVersion == "Daily") return "dag";
  if (englishVersion == "Weekly") return "vecka";
  if (englishVersion == "Monthly") return "månad";
}
