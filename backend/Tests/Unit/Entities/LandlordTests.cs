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
            var name = "John Doe";
            var image = CreateImage();
            var contactPhone = new PhoneNumber("0701234567");
            var contactEmail = new EmailAddress("random@example.com");

            var landlord = new Landlord(identityId, name, image, contactPhone, contactEmail);

            Assert.NotEqual(landlord.Id, Guid.Empty);
            Assert.Equal(identityId, landlord.IdentityId);

            Assert.NotNull(landlord.Profile);
            Assert.Same(landlord, landlord.Profile.Landlord);
            Assert.Equal(landlord.Id, landlord.Profile.LandlordId);

            Assert.Equal(name, landlord.Profile.Name);
            Assert.Equal(image, landlord.Profile.Image);
            Assert.Equal(contactPhone, landlord.Profile.ContactPhone);
            Assert.Equal(contactEmail, landlord.Profile.ContactEmail);
        }

        [Fact]
        public void Constructor_WithPhoneNumberMinimalValidParameters_ShouldSucceed()
        {
            var identityId = "SomeIdentityId";
            var name = "John Doe";
            var contactPhone = new PhoneNumber("0701234567");

            var landlord = new Landlord(identityId, name, contactPhone: contactPhone);

            Assert.NotEqual(landlord.Id, Guid.Empty);
            Assert.Equal(identityId, landlord.IdentityId);

            Assert.NotNull(landlord.Profile);
            Assert.Same(landlord, landlord.Profile.Landlord);
            Assert.Equal(landlord.Id, landlord.Profile.LandlordId);

            Assert.Equal(name, landlord.Profile.Name);
            Assert.Null(landlord.Profile.Image);
            Assert.Equal(contactPhone, landlord.Profile.ContactPhone);
            Assert.Null(landlord.Profile.ContactEmail);
        }

        [Fact]
        public void Constructor_WithEmailAddressMinimalValidParameters_ShouldSucceed()
        {
            var identityId = "SomeIdentityId";
            var name = "John Doe";
            var contactEmail = new EmailAddress("random@example.com");

            var landlord = new Landlord(identityId, name, contactEmail: contactEmail);

            Assert.NotEqual(landlord.Id, Guid.Empty);
            Assert.Equal(identityId, landlord.IdentityId);

            Assert.NotNull(landlord.Profile);
            Assert.Same(landlord, landlord.Profile.Landlord);
            Assert.Equal(landlord.Id, landlord.Profile.LandlordId);

            Assert.Equal(name, landlord.Profile.Name);
            Assert.Null(landlord.Profile.Image);
            Assert.Null(landlord.Profile.ContactPhone);
            Assert.Equal(contactEmail, landlord.Profile.ContactEmail);
        }

        [Fact]
        public void Constructor_WithNullIdentityId_ShouldThrow()
        {
            string? identityId = null;
            var name = "John Doe";
            var image = CreateImage();
            var contactPhone = new PhoneNumber("0701234567");
            var contactEmail = new EmailAddress("random@example.com");

            Assert.Throws<ArgumentNullException>(()
                =>  new Landlord(identityId!, name, image, contactPhone, contactEmail));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_WithInvalidIdentityId_ShouldThrow(string identityId)
        {
            var name = "John Doe";
            var image = CreateImage();
            var contactPhone = new PhoneNumber("0701234567");
            var contactEmail = new EmailAddress("random@example.com");

            Assert.Throws<ArgumentException>(()
             => new Landlord(identityId, name, image, contactPhone, contactEmail));
        }

        [Fact]
        public void Constructor_WithNullName_ShouldThrow()
        {
            var identityId = "SomeIdentityId";
            string? name = null;
            var image = CreateImage();
            var contactPhone = new PhoneNumber("0701234567");
            var contactEmail = new EmailAddress("random@example.com");

            Assert.Throws<ArgumentNullException>(()
                => new Landlord(identityId, name!, image, contactPhone, contactEmail));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_WithInvalidName_ShouldThrow(string name)
        {
            var identityId = "SomeIdentityId";
            var image = CreateImage();
            var contactPhone = new PhoneNumber("0701234567");
            var contactEmail = new EmailAddress("random@example.com");

            Assert.Throws<ArgumentException>(()
             => new Landlord(identityId, name, image, contactPhone, contactEmail));
        }

        [Fact]
        public void Constructor_WithNoContactMethod_ShouldThrow()
        {
            var identityId = "SomeIdentityId";
            var name = "John Doe";

            Assert.Throws<ArgumentException>(()
                => new Landlord(identityId, name));
        }

        private static Image CreateImage()
        {
            var url = new WebAddress("https://example.com");
            return new Image(url, "SomeAltText");
        }
    }
}
