using Domain.ValueObjects;

namespace Tests.Unit.ValueObjects
{
    public class WebAddressTests
    {
        [Theory]
        [InlineData("https://example.com")]
        [InlineData("https://www.example.com")]
        [InlineData("http://localhost:5000")]
        public void Constructor_WithValidUrl_ShouldSucceed(string url)
        {
            var webAddress = new WebAddress(url);

            Assert.Equal(url, webAddress.Value);
        }

        [Fact]
        public void Constructor_WithNullUrl_ShouldThrow()
        {
            string? url = null;

            Assert.Throws<ArgumentNullException>(()
                => new WebAddress(url!));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("SomeWords")]
        [InlineData("example.com")]
        [InlineData("htps://example.com")]
        public void Constructor_WithInvalidUrl_ShouldThrow(string url)
        {
            Assert.Throws<ArgumentException>(()
                => new WebAddress(url));
        }
    }
}
