namespace Domain.ValueObjects
{
    public record WebAddress
    {
        public string Value { get; }

        public WebAddress(string url)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(url);

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                throw new ArgumentException("Invalid web address.", nameof(url));

            Value = url;
        }

        private WebAddress() { Value = default!; }
    }
}
