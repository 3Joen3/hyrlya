using System.ComponentModel.DataAnnotations;

namespace Api.Requests
{
    public class LandlordRequest
    {
        [Required, MinLength(1)]
        public string Name { get; init; } = default!;

        [Required]
        public LandlordContactRequest ContactMethod { get; init; } = default!;

        public string? ProfileImageUrl { get; init; }
    }

    public class LandlordContactRequest : IValidatableObject
    {
        public string? PhoneNumber { get; init; }
        public string? EmailAddress { get; init; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(PhoneNumber) && string.IsNullOrWhiteSpace(EmailAddress))
                yield return new ValidationResult("A contact method is required. Phone number or email address.");
        }
    }
}
