using Domain.Entities;
using Domain.ValueObjects;

namespace Tests.Unit.Entities
{
    public class LandlordTests
    {
        [Fact]
        public void Constructor_WithFullValidParameters_ShouldSucceed()
        {
            var identityId = "SomeIdentityId";
            var profileName = "John Doe";
            var profileImageUrl = new WebAddress("https://example.com/image/123");
            var profilePhone = new PhoneNumber("0712345678");
            var profileEmail = new EmailAddress("example@example.com");

            var landlord = new Landlord(identityId, profileName, 
                profileImageUrl, profilePhone, profileEmail);

            Assert.NotEqual(Guid.Empty, landlord.Id);

            Assert.Equal(identityId, landlord.IdentityId);

            Assert.Equal(profileName, landlord.Profile.Name);
            Assert.NotNull(landlord.Profile.Image);
            Assert.Equal(profileImageUrl, landlord.Profile.Image.Url);
            Assert.Equal(profilePhone, landlord.Profile.PhoneNumber);
            Assert.Equal(profileEmail, landlord.Profile.EmailAddress);

            Assert.Empty(landlord.RentalUnits);
        }

        [Fact]
        public void Constructor_WithProfilePhoneMinimalValidParameters_ShouldSucceed()
        {
            var identityId = "SomeIdentityId";
            var profileName = "John Doe";
            var profilePhone = new PhoneNumber("0712345678");

            var landlord = new Landlord(identityId, profileName, profilePhone: profilePhone);

            Assert.NotEqual(Guid.Empty, landlord.Id);

            Assert.Equal(identityId, landlord.IdentityId);

            Assert.Equal(profileName, landlord.Profile.Name);
            Assert.Null(landlord.Profile.Image);
            Assert.Equal(profilePhone, landlord.Profile.PhoneNumber);
            Assert.Null(landlord.Profile.EmailAddress);

            Assert.Empty(landlord.RentalUnits);
        }

        [Fact]
        public void Constructor_WithProfileEmailMinimalValidParameters_ShouldSucceed()
        {
            var identityId = "SomeIdentityId";
            var profileName = "John Doe";
            var profileEmail = new EmailAddress("example@example.com");

            var landlord = new Landlord(identityId, profileName, profileEmail: profileEmail);

            Assert.NotEqual(Guid.Empty, landlord.Id);

            Assert.Equal(identityId, landlord.IdentityId);

            Assert.Equal(profileName, landlord.Profile.Name);
            Assert.Null(landlord.Profile.Image);
            Assert.Null(landlord.Profile.PhoneNumber);
            Assert.Equal(profileEmail, landlord.Profile.EmailAddress);

            Assert.Empty(landlord.RentalUnits);
        }

        [Fact]
        public void Constructor_WithNullIdentityId_ShouldThrow()
        {
            string? identityId = null;
            var profileName = "John Doe";
            var profileImageUrl = new WebAddress("https://example.com/image/123");
            var profilePhone = new PhoneNumber("0712345678");
            var profileEmail = new EmailAddress("example@example.com");

            Assert.Throws<ArgumentNullException>(()
                => new Landlord(identityId!, profileName, profileImageUrl, profilePhone, profileEmail));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WithEmptyIdentityId_ShouldThrow(string identityId)
        {
            var profileName = "John Doe";
            var profileImageUrl = new WebAddress("https://example.com/image/123");
            var profilePhone = new PhoneNumber("0712345678");
            var profileEmail = new EmailAddress("example@example.com");

            Assert.Throws<ArgumentException>(()
                => new Landlord(identityId, profileName, profileImageUrl, profilePhone, profileEmail));
        }

        [Fact]
        public void Constructor_WithNullProfileName_ShouldThrow()
        {
            var identityId = "SomeIdentityId";
            string? profileName = null;
            var profileImageUrl = new WebAddress("https://example.com/image/123");
            var profilePhone = new PhoneNumber("0712345678");
            var profileEmail = new EmailAddress("example@example.com");

            Assert.Throws<ArgumentNullException>(() 
                => new Landlord(identityId, profileName!, profileImageUrl, profilePhone, profileEmail));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WithEmptyProfileName_ShouldThrow(string profileName)
        {
            var identityId = "SomeIdentityId";
            var profileImageUrl = new WebAddress("https://example.com/image/123");
            var profilePhone = new PhoneNumber("0712345678");
            var profileEmail = new EmailAddress("example@example.com");

            Assert.Throws<ArgumentException>(() 
                => new Landlord(identityId, profileName, profileImageUrl, profilePhone, profileEmail));
        }

        [Fact]
        public void Constructor_WithoutContactMethod_ShouldThrow()
        {
            var identityId = "SomeIdentityId";
            var profileName = "John Doe";

            Assert.Throws<ArgumentException>(()
                => new Landlord(identityId, profileName));
        }
    }
}
