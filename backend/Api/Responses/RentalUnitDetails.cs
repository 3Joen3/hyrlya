using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Responses
{
    public class RentalUnitDetails(RentalUnit rentalUnit)
    {
        public IEnumerable<Image> Images { get; } = rentalUnit.Images;
    }
}
