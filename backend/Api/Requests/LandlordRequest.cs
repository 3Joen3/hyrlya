using System.ComponentModel.DataAnnotations;

namespace Api.Requests
{
    public class LandlordRequest : IValidatableObject
    {
        [Required, MinLength(1)]
        public string Name { get; init; } = default!;

        [MinLength(1)]
        public string? ProfileImageUrl { get; init; }

        [MinLength(1)]
        public string? PhoneNumber { get; init; }

        [MinLength(1)]
        public string? EmailAddress { get; init; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(PhoneNumber) && string.IsNullOrWhiteSpace(EmailAddress))
                yield return new ValidationResult("A contact method is required. Phone number or email address.");
        }
    }
}
