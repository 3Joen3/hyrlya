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
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_WithInvalidIdentityId_ShouldThrow(string identityId)
        {
            Assert.Throws<ArgumentException>(()
                => new Landlord(identityId));
        }
    }
}
