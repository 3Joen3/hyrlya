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
            var landlordId = Guid.NewGuid();
            var address = new Address("SomeStreet", "123", "SomeCity");
            var type = RentalUnitType.Apartment;
            var numberOfRooms = 4;
            var size = 100;
            var images = CreateImages();

            var rentalUnit = new RentalUnit(landlordId, address, type, numberOfRooms, size, images);

            Assert.NotEqual(rentalUnit.Id, Guid.Empty);

            Assert.NotEqual(rentalUnit.LandlordId, Guid.Empty);
            Assert.Equal(landlordId, rentalUnit.LandlordId);

            Assert.NotNull(rentalUnit.Address);
            Assert.Equal(address, rentalUnit.Address);

            Assert.Equal(type, rentalUnit.Type);

            Assert.Equal(numberOfRooms, rentalUnit.NumberOfRooms);

            Assert.Equal(size, rentalUnit.SizeSquareMeters);

            Assert.NotNull(rentalUnit.Images);
            Assert.NotEmpty(rentalUnit.Images);
            Assert.Equal(images, rentalUnit.Images);
        }

        [Fact]
        public void Constructor_WithEmptyLandlordId_ShouldThrow()
        {
            var landlordId = Guid.Empty;
            var address = new Address("SomeStreet", "123", "SomeCity");
            var type = RentalUnitType.Apartment;
            var numberOfRooms = 4;
            var size = 100;
            var images = CreateImages();

            Assert.Throws<ArgumentException>(()
               => new RentalUnit(landlordId, address, type, numberOfRooms, size, images));
        }

        [Fact]
        public void Constructor_WithNullAddress_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            Address? address = null;
            var type = RentalUnitType.Apartment;
            var numberOfRooms = 4;
            var size = 100;
            var images = CreateImages();

            Assert.Throws<ArgumentNullException>(()
               => new RentalUnit(landlordId, address!, type, numberOfRooms, size, images));
        }

        [Fact]
        public void Constructor_WithZeroRooms_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var address = new Address("SomeStreet", "123", "SomeCity");
            var type = RentalUnitType.Apartment;
            var numberOfRooms = 0;
            var size = 100;
            var images = CreateImages();

            Assert.Throws<ArgumentOutOfRangeException>(()
               => new RentalUnit(landlordId, address, type, numberOfRooms, size, images));
        }

        [Fact]
        public void Constructor_WithZeroSize_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var address = new Address("SomeStreet", "123", "SomeCity");
            var type = RentalUnitType.Apartment;
            var numberOfRooms = 4;
            var size = 0;
            var images = CreateImages();

            Assert.Throws<ArgumentOutOfRangeException>(()
               => new RentalUnit(landlordId, address, type, numberOfRooms, size, images));
        }

        [Fact]
        public void Constructor_WithNullImages_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var address = new Address("SomeStreet", "123", "SomeCity");
            var type = RentalUnitType.Apartment;
            var numberOfRooms = 4;
            var size = 100;
            List<Image>? images = null;

            Assert.Throws<ArgumentNullException>(() 
                => new RentalUnit(landlordId, address, type, numberOfRooms, size, images!));
        }

        [Fact]
        public void Constructor_WithEmptyImages_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var address = new Address("SomeStreet", "123", "SomeCity");
            var type = RentalUnitType.Apartment;
            var numberOfRooms = 4;
            var size = 100;
            var images = new List<Image>();

            Assert.Throws<ArgumentException>(() 
                => new RentalUnit(landlordId, address, type, numberOfRooms, size, images));
        }

        [Fact]
        public void Constructor_WithNullImage_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var address = new Address("SomeStreet", "123", "SomeCity");
            var type = RentalUnitType.Apartment;
            var numberOfRooms = 4;
            var size = 100;
            var images = new List<Image?>() { null };

            Assert.Throws<ArgumentNullException>(()
               => new RentalUnit(landlordId, address, type, numberOfRooms, size, images!));
        }

        [Fact]
        public void ChangeAddress_WithValidAddress_ShouldReplaceAddress()
        {
            var rentalUnit = CreateRentalUnitWithFullValidParameters();
            var newAddress = new Address("NewSomeStreet", "321", "NewSomeCity");

            rentalUnit.ChangeAddress(newAddress);

            Assert.Equal(newAddress, rentalUnit.Address);
        }

        [Fact]
        public void ChangeAddress_WithNullAddress_ShouldThrow()
        {
            var rentalUnit = CreateRentalUnitWithFullValidParameters();
            Address? newAddress = null;

            Assert.Throws<ArgumentNullException>(()
                => rentalUnit.ChangeAddress(newAddress!));
        }

        [Fact]
        public void ChangeType_WithValidType_ShouldReplaceType()
        {
            var rentalUnit = CreateRentalUnitWithFullValidParameters();
            var newType = RentalUnitType.House;

            rentalUnit.ChangeType(newType);

            Assert.Equal(newType, rentalUnit.Type);
        }

        [Fact]
        public void ChangeNumberOfRooms_WithValidValue_ShouldReplaceRooms()
        {
            var rentalUnit = CreateRentalUnitWithFullValidParameters();
            var newNumberOfRooms = 5;

            rentalUnit.ChangeNumberOfRooms(newNumberOfRooms);

            Assert.Equal(newNumberOfRooms, rentalUnit.NumberOfRooms);
        }

        [Fact]
        public void ChangeNumberOfRooms_WithZero_ShouldThrow()
        {
            var rentalUnit = CreateRentalUnitWithFullValidParameters();
            var newNumberOfRooms = 0;

            Assert.Throws<ArgumentOutOfRangeException>(()
                => rentalUnit.ChangeNumberOfRooms(newNumberOfRooms));
        }

        [Fact]
        public void ChangeSizeSquareMeters_WithValidValue_ShouldReplaceSize()
        {
            var rentalUnit = CreateRentalUnitWithFullValidParameters();
            var newSizeSquareMeters = 123;

            rentalUnit.ChangeSizeSquareMeters(newSizeSquareMeters);

            Assert.Equal(newSizeSquareMeters, rentalUnit.SizeSquareMeters);
        }

        [Fact]
        public void ChangeSizeSquareMeters_WithZero_ShouldThrow()
        {
            var rentalUnit = CreateRentalUnitWithFullValidParameters();
            var newSizeSquareMeters = 0;

            Assert.Throws<ArgumentOutOfRangeException>(()
                => rentalUnit.ChangeNumberOfRooms(newSizeSquareMeters));
        }

        private static RentalUnit CreateRentalUnitWithFullValidParameters()
        {
            return new RentalUnit(
                Guid.NewGuid(),
                new Address("SomeStreet", "123", "SomeCity"),
                RentalUnitType.Apartment,
                4,
                100,
                CreateImages()
            );
        }

        private static List<Image> CreateImages()
        {
            var url = new WebAddress("https://example.com");
            var image = new Image(url, "SomeAltText");
            return [image];
        }
    }
}
