using Domain.Entities;

namespace Tests.Unit.Entities
{
    public class LandlordProfileTests
    {
        [Fact]
        public void Constructor_WithFullValidParameters_ShouldSucceed()
        {
            var profileImage = new LandlordProfileImage("SomeUrl", "SomeAltText");

            var profile = new LandlordProfile(profileImage);

            Assert.NotEqual(Guid.Empty, profile.Id);
            Assert.Equal(profileImage, profile.Image);
        }

        [Fact]
        public void Constructor_WithMinimalValidParameters_ShouldSucceed()
        {
            var profile = new LandlordProfile();

            Assert.NotEqual(Guid.Empty, profile.Id);
            Assert.Null(profile.Image);
        }
    }
}
