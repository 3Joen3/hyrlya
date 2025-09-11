using Domain.Entities;

namespace Tests.Unit.Entities
{
    public class LandlordProfileImageTests
    {
        [Fact]
        public void Constructor_WithFullValidParameters_ShouldSucceed()
        {
            var url = "SomeUrl";
            var altText = "SomeAltText";

            var profileImage = new LandlordProfileImage(url, altText);

            Assert.NotEqual(Guid.Empty, profileImage.Id);
            Assert.Equal(Guid.Empty, profileImage.LandlordProfileId);
            Assert.Null(profileImage.LandlordProfile);
            Assert.Equal(url, profileImage.Url);
            Assert.Equal(altText, profileImage.AltText);
        }

        [Fact]
        public void Constructor_WithMinimalValidParameters_ShouldSucceed()
        {
            var url = "SomeUrl";

            var profileImage = new LandlordProfileImage(url);

            Assert.NotEqual(Guid.Empty, profileImage.Id);
            Assert.Equal(Guid.Empty, profileImage.LandlordProfileId);
            Assert.Null(profileImage.LandlordProfile);
            Assert.Equal(url, profileImage.Url);
            Assert.Null(profileImage.AltText);
        }

        [Fact]
        public void Constructor_WithNullUrl_ShouldThrow()
        {
            string? url = null;
            var altText = "SomeAltText";

            Assert.Throws<ArgumentNullException>(() 
                => new LandlordProfileImage(url!, altText));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WithInvalidUrl_ShouldThrow(string url)
        {
            var altText = "SomeAltText";

            Assert.Throws<ArgumentException>(() 
                => new LandlordProfileImage(url, altText));
        }
    }
}
