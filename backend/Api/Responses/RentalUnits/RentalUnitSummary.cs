using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Responses.RentalUnits
{
    public class RentalUnitSummary(RentalUnit rentalUnit)
    {
        public Guid Id { get; } = rentalUnit.Id;
        public string Type { get; } = rentalUnit.Type.ToString();
        public Address Address { get; } = rentalUnit.Address;
    }
}
