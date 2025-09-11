using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public partial record PhoneNumber
    {
        public string Value { get; }

        public PhoneNumber(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            var cleaned = Normalize(value);

            if (!SwedishPhoneRegex().IsMatch(cleaned))
                throw new ArgumentException("Invalid Swedish phone number.", nameof(value));

            Value = cleaned;
        }

        private static string Normalize(string input) 
            => input.Trim().Replace(" ", "").Replace("-", "");

        [GeneratedRegex(@"^(?:\+46|0)7\d{8}$", RegexOptions.Compiled)]
        private static partial Regex SwedishPhoneRegex();

        private PhoneNumber() { Value = default!; }
    }
}
