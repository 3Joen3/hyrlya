using System.ComponentModel.DataAnnotations;

namespace Api.ValidationAttributes
{
    public class MinCountAttribute(int minCount) : ValidationAttribute
    {
        private readonly int _minCount = minCount;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IEnumerable<object> collection)
            {
                var count = collection.Count();

                if (count < _minCount)
                    return new ValidationResult($"Collection must contain at least {_minCount} item(s).");
            }

            return ValidationResult.Success;
        }
    }
}
