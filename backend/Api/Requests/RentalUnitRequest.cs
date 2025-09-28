using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Requests
{
    public class RentalUnitRequest : IValidatableObject
    {
        [Required]
        public AddressRequest Address { get; init; } = default!;

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RentalUnitType Type { get; init; }

        [Required]
        [MinLength(1)]
        public string Description { get; init; } = default!;

        [Range(1, int.MaxValue)]
        public int NumberOfRooms { get; init; }

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
    }
}
