"use server";

import { postAuthenticated, putAuthenticated } from "../api/server";
import { RentalUnitData, rentalUnitSchema } from "../schemas/rentalUnitSchema";

export async function createRentalUnit(data: RentalUnitData) {
  const parsed = rentalUnitSchema.parse(data);
  console.log(parsed);
  const response = await postAuthenticated("my/rental-units", parsed);
  console.log(response);
}

export async function updateRentalUnit(data: RentalUnitData, id: string) {
  const parsed = rentalUnitSchema.parse(data);
  const response = await putAuthenticated(`my/rental-units/${id}`, parsed);
}
