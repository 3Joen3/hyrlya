using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Responses
{
    public class RentalUnitSummary(RentalUnit rentalUnit)
    {
        public Guid Id { get; } = rentalUnit.Id;
        public Address Address { get; } = rentalUnit.Address;
    }
}
