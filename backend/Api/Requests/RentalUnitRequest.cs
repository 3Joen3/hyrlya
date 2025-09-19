using Application.Dtos;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Requests
{
    public class RentalUnitRequest : IValidatableObject
    {
        [Required, MinLength(1)]
        public string Street { get; init; } = default!;

        [Required, MinLength(1)]
        public string HouseNumber { get; init; } = default!;

        [Required, MinLength(1)]
        public string City { get; init; } = default!;

        [Required]
        public RentalUnitType Type { get; init; }

        [Range(1, int.MaxValue)]
        public int Rooms { get; init; }

        [Range(1, int.MaxValue)]
        public int SizeSquareMeters { get; init; }

        [Required]
        public IEnumerable<string> ImageUrls { get; init; } = default!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!ImageUrls.Any())
                yield return new ValidationResult("At least one image is required.");
            else if (ImageUrls.Any(img => string.IsNullOrWhiteSpace(img)))
                yield return new ValidationResult("An image can't be null or empty string.");
        }

        public RentalUnitDto ToDto()
        {
            return new RentalUnitDto
            {
                Street = Street,
                HouseNumber = HouseNumber,
                City = City,
                Type = Type,
                NumberOfRooms = Rooms,
                SizeSquareMeters = SizeSquareMeters,
                ImageUrls = ImageUrls
            };
        }
    }
}
