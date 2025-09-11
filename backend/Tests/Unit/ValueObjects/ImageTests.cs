using Domain.ValueObjects;

namespace Tests.Unit.ValueObjects
{
    public class ImageTests
    {
        [Fact]
        public void Constructor_WithFullValidParameters_ShouldSucceed()
        {
            var url = new WebAddress("https://example.com");
            var altText = "SomeAltText";

            var image = new Image(url, altText);

            Assert.Equal(url, image.Url);
            Assert.Equal(altText, image.AltText);
        }

        [Fact]
        public void Constructor_WithNullWebAddress_ShouldThrow()
        {
            WebAddress? webAddress = null;
            var altText = "SomeAltText";

            Assert.Throws<ArgumentNullException>(()
                => new Image(webAddress!, altText));
        }

        [Fact]
        public void Constructor_WithNullAltText_ShouldThrow()
        {
            var url = new WebAddress("https://example.com");
            string? altText = null;

            Assert.Throws<ArgumentNullException>(()
                => new Image(url, altText!));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WithInvalidAltText_ShouldThrow(string altText)
        {
            var url = new WebAddress("https://example.com");

            Assert.Throws<ArgumentException>(()
                => new Image(url, altText));
        }
    }
}
