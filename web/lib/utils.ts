export function TranslateRentalUnitType(englishVersion: string) {
  if (englishVersion === "Room") return "Rum";
  if (englishVersion === "Apartment") return "Lägenhet";
  return "Hus";
}

export function TranslateRentalPriceChargeInterval(englishVersion: string) {
  if (englishVersion == "daily") return "dag";
  if (englishVersion == "weekly") return "vecka";
  if (englishVersion == "monthly") return "månad";
}
