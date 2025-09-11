using Domain.Entities;

namespace Tests.Unit.Entities
{
    public class LandlordTests
    {
        [Fact]
        public void Constructor_WithFullValidParameters_ShouldSucceed()
        {
            var identityId = "SomeIdentityId";

            var landlord = new Landlord(identityId);

            Assert.NotEqual(landlord.Id, Guid.Empty);
            Assert.Equal(identityId, landlord.IdentityId);
            Assert.Null(landlord.Profile);
        }

        [Fact]
        public void Constructor_WithNullIdentityId_ShouldThrow()
        {
            string? identityId = null;

            Assert.Throws<ArgumentNullException>(()
                =>  new Landlord(identityId!));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_WithInvalidIdentityId_ShouldThrow(string identityId)
        {
            Assert.Throws<ArgumentException>(()
                => new Landlord(identityId));
        }
    }
}
