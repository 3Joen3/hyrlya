namespace Domain.ValueObjects
{
    public record Image
    {
        public WebAddress Url { get; }
        public string AltText { get; }

        public Image(WebAddress url, string altText)
        {
            ArgumentNullException.ThrowIfNull(url);
            ArgumentException.ThrowIfNullOrWhiteSpace(altText);

            Url = url;
            AltText = altText;
        }
    }
}
