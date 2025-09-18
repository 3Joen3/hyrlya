using Domain.Entities;

namespace Api.Responses
{
    public class RentalUnitDetails(RentalUnit rentalUnit)
    {
        public IEnumerable<ImageResponse> Images { get; } = rentalUnit.Images
            .Select(img => new ImageResponse(img));
    }
}
