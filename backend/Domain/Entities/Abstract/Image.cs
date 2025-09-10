namespace Domain.Entities.Abstract
{
    public abstract class Image : Entity
    {
        public string Url { get; private set; }
        public string AltText { get; private set; }

        protected Image(string url, string altText)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(url);
            ArgumentException.ThrowIfNullOrWhiteSpace(altText);

            Url = url;
            AltText = altText;
        }

        protected Image() { Url = default!; AltText = default!; }
    }
}
