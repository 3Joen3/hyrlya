export function TranslateRentalUnitType(englishType: string) {
  if (englishType === "Room") return "Rum";
  if (englishType === "Apartment") return "Lägenhet";
  return "Hus";
}
