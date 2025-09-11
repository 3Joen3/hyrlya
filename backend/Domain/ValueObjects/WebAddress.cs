namespace Domain.ValueObjects
{
    public record WebAddress
    {
        public string Value { get; }

        public WebAddress(string url)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(url);

            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri)
                || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
                || string.IsNullOrWhiteSpace(uri.Host))
                throw new ArgumentException("Invalid web address.", nameof(url));

            Value = url;
        }

        private WebAddress() { Value = default!; }
    }
}
