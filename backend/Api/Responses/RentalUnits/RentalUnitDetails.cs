using Api.Responses.Common;
using Domain.Entities;

namespace Api.Responses.RentalUnits
{
    public class RentalUnitDetails(RentalUnit rentalUnit)
    {
        public IEnumerable<ImageResponse> Images { get; } = rentalUnit.Images
            .Select(img => new ImageResponse(img));
    }
}
