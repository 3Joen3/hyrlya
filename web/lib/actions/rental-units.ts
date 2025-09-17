"use server";

import { postAuthenticated } from "../api/server";
import { RentalUnitData, rentalUnitSchema } from "../schemas/rentalUnitSchema";

export async function createRentalUnit(data: RentalUnitData) {
  const parsed = rentalUnitSchema.parse(data);
  console.log(parsed);
  const response = await postAuthenticated("rentalunits", parsed);
  console.log(response);

}
