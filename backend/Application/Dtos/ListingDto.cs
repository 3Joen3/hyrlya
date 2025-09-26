using Domain.ValueObjects;

namespace Application.Dtos
{
    public record ListingDto(Guid RentalUnitId, RentalPrice RentalPrice);
}
