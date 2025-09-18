export interface RentalUnitSummary {
  id: string;
  address: Address;
}

export interface Address {
  street: string;
  houseNumber: string;
  city: string;
}
