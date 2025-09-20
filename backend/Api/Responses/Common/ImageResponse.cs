using Domain.ValueObjects;

namespace Api.Responses.Common
{
    public class ImageResponse(Image image)
    {
        public string Url { get; } = image.Url.Value;
        public string AltText { get; } = image.AltText;
    }
}
