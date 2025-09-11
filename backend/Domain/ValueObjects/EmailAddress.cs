using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public partial record EmailAddress
    {
        public string Value { get; }

        public EmailAddress(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            if (!EmailRegex().IsMatch(value))
                throw new ArgumentException("Invalid email address.", nameof(value));

            Value = value;
        }

        public override string ToString() => Value;

        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled)]
        private static partial Regex EmailRegex();

        private EmailAddress() { Value = default!; }
    }
}
