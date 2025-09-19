using Domain.Enums;

namespace Application.Dtos
{
    public class RentalUnitDto
    {
        public required string Street { get; init; }
        public required string HouseNumber { get; init; }
        public required string City { get; init; }

        public required RentalUnitType Type { get; init; }
        public required int NumberOfRooms { get; init; }
        public required int SizeSquareMeters { get; init; }
        public required IEnumerable<string> ImageUrls { get; init; }
    }
}
