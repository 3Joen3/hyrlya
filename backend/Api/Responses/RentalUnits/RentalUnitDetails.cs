using Api.Responses.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Responses.RentalUnits
{
    public class RentalUnitDetails(RentalUnit rentalUnit)
    {
        public Guid Id { get; } = rentalUnit.Id;
        public string Type { get; } = rentalUnit.Type.ToString();
        public Address Address { get; } = rentalUnit.Address;
        public int NumberOfRooms { get; } = rentalUnit.NumberOfRooms;
        public int SizeSquareMeters { get; } = rentalUnit.SizeSquareMeters;
        public IEnumerable<ImageResponse> Images { get; } = rentalUnit.Images.Select(img => new ImageResponse(img));
        public string Description { get; } = rentalUnit.Description;
    }
}
