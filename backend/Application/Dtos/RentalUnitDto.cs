using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Dtos
{
    public class RentalUnitDto
    {
        public required Address Address { get; init; } = default!;
        public required RentalUnitType Type { get; init; }
        public required int NumberOfRooms { get; init; }
        public required int SizeSquareMeters { get; init; }
        public required IEnumerable<WebAddress> ImageUrls { get; init; }
    }
}
