using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Tests.Unit.Entities
{
    public class RentalUnitTests
    {
        [Fact]
        public void Constructor_WithFullValidParameters_ShouldSucceed()
        {
            var images = CreateImages();
            var address = new Address("SomeStreet", "14", "Borås"); ;
            var landlordId = Guid.NewGuid();

            var rentalUnit = new RentalUnit(images, address, RentalUnitType.Apartment, landlordId);

            Assert.NotEqual(rentalUnit.Id, Guid.Empty);

            Assert.NotNull(rentalUnit.Images);
            Assert.Single(rentalUnit.Images);
            Assert.NotNull(rentalUnit.Images[0]);
            Assert.Equal(images[0], rentalUnit.Images[0]);

            Assert.NotNull(rentalUnit.Address);
            Assert.Equal(address, rentalUnit.Address);

            Assert.Equal(RentalUnitType.Apartment, rentalUnit.Type);

            Assert.NotEqual(rentalUnit.LandlordId, Guid.Empty);
            Assert.Equal(landlordId, rentalUnit.LandlordId);

            Assert.Null(rentalUnit.Landlord);
        }

        [Fact]
        public void Constructor_WithNullImages_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            List<Image>? images = null;
            var address = new Address("SomeStreet", "14", "Borås"); ;

            Assert.Throws<ArgumentNullException>(()
               => new RentalUnit(images!, address, RentalUnitType.Apartment, landlordId));
        }

        [Fact]
        public void Constructor_WithEmptyImages_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var images = new List<Image>();
            var address = new Address("SomeStreet", "14", "Borås"); ;

            Assert.Throws<ArgumentException>(()
             => new RentalUnit(images, address, RentalUnitType.Apartment, landlordId));
        }

        [Fact]
        public void Constructor_WithNullImage_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var images = new List<Image>() { null! };
            var address = new Address("SomeStreet", "14", "Borås"); ;

            Assert.Throws<ArgumentNullException>(()
             => new RentalUnit(images, address, RentalUnitType.Apartment, landlordId));
        }

        [Fact]
        public void Constructor_WithNullAddress_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var images = CreateImages();
            Address? address = null;

            Assert.Throws<ArgumentNullException>(()
             => new RentalUnit(images, address!, RentalUnitType.Apartment, landlordId));
        }

        [Fact]
        public void Constructor_WithEmptyLandlordId_ShouldThrow()
        {
            var landlordId = Guid.Empty;
            var images = CreateImages();
            var address = new Address("SomeStreet", "14", "Borås");

            Assert.Throws<ArgumentException>(()
             => new RentalUnit(images, address, RentalUnitType.Apartment, landlordId));
        }

        private static List<Image> CreateImages()
        {
            var url = new WebAddress("https://example.com");
            var image = new Image(url, "SomeAltText");
            return [image];
        }
    }
}
