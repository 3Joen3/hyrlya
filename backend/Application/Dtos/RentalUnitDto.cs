using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Dtos
{
    public record RentalUnitDto(
        Address Address, 
        RentalUnitType Type, 
        string Description,
        int NumberOfRooms, 
        int SizeSquareMeters, 
        IEnumerable<WebAddress> ImageUrls
    );
}
