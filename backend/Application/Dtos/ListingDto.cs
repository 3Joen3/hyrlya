using Domain.Enums;

namespace Application.Dtos
{
    public record ListingDto(Guid RentalUnitId, RentalType RentalType);
}
