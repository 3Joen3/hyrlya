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
            var address = new Address("SomeStreet", "4", "Borås");
            var type = RentalUnitType.Apartment;
            var description = "Some description";
            var numberOfRooms = 3;
            var sizeSquareMeters = 83;
            var imageUrls = new List<WebAddress>() { new("https://example.com/image/123") };

            var rentalUnit = new RentalUnit(landlordId, address, type, description,
                numberOfRooms, sizeSquareMeters, imageUrls);

            Assert.NotEqual(Guid.Empty, rentalUnit.Id);
            Assert.Equal(landlordId, rentalUnit.LandlordId);
            Assert.Equal(address, rentalUnit.Address);
            Assert.Equal(type, rentalUnit.Type);
            Assert.Equal(description, rentalUnit.Description);
            Assert.Equal(numberOfRooms, rentalUnit.NumberOfRooms);
            Assert.Equal(sizeSquareMeters, rentalUnit.SizeSquareMeters);
            Assert.Equal(imageUrls[0], rentalUnit.Images[0].Url);
        }

        [Fact]
        public void Constructor_WithEmptyLandlordId_ShouldThrow()
        {
            var landlordId = Guid.Empty;
            var address = new Address("SomeStreet", "4", "Borås");
            var type = RentalUnitType.Apartment;
            var description = "Some description";
            var numberOfRooms = 3;
            var sizeSquareMeters = 83;
            var imageUrls = new List<WebAddress>() { new("https://example.com/image/123") };

            Assert.Throws<ArgumentException>(() 
                => new RentalUnit(landlordId, address, type, description, numberOfRooms, sizeSquareMeters, imageUrls));
        }

        [Fact]
        public void Constructor_WithNullAddress_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            Address? address = null;
            var type = RentalUnitType.Apartment;
            var description = "Some description";
            var numberOfRooms = 3;
            var sizeSquareMeters = 83;
            var imageUrls = new List<WebAddress>() { new("https://example.com/image/123") };

            Assert.Throws<ArgumentNullException>(()
                => new RentalUnit(landlordId, address!, type, description, numberOfRooms, sizeSquareMeters, imageUrls));
        }

        [Fact]
        public void Constructor_WithZeroNumberOfRooms_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var address = new Address("SomeStreet", "4", "Borås");
            var type = RentalUnitType.Apartment;
            var description = "Some description";
            var numberOfRooms = 0;
            var sizeSquareMeters = 83;
            var imageUrls = new List<WebAddress>() { new("https://example.com/image/123") };

            Assert.Throws<ArgumentOutOfRangeException>(()
                => new RentalUnit(landlordId, address, type, description, numberOfRooms, sizeSquareMeters, imageUrls));
        }

        [Fact]
        public void Constructor_WithZeroSizeSquareMeters_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var address = new Address("SomeStreet", "4", "Borås");
            var type = RentalUnitType.Apartment;
            var description = "Some description";
            var numberOfRooms = 3;
            var sizeSquareMeters = 0;
            var imageUrls = new List<WebAddress>() { new("https://example.com/image/123") };

            Assert.Throws<ArgumentOutOfRangeException>(()
                => new RentalUnit(landlordId, address, type, description, numberOfRooms, sizeSquareMeters, imageUrls));
        }

        [Fact]
        public void Constructor_WithNullImageUrls_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var address = new Address("SomeStreet", "4", "Borås");
            var type = RentalUnitType.Apartment;
            var description = "Some description";
            var numberOfRooms = 3;
            var sizeSquareMeters = 83;
            List<WebAddress>? imageUrls = null;

            Assert.Throws<ArgumentNullException>(()
                => new RentalUnit(landlordId, address, type, description, numberOfRooms, sizeSquareMeters, imageUrls!));
        }

        [Fact]
        public void Constructor_WithEmptyImageUrls_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var address = new Address("SomeStreet", "4", "Borås");
            var type = RentalUnitType.Apartment;
            var description = "Some description";
            var numberOfRooms = 3;
            var sizeSquareMeters = 83;
            var imageUrls = new List<WebAddress>() { };

            Assert.Throws<ArgumentException>(()
                => new RentalUnit(landlordId, address, type, description, numberOfRooms, sizeSquareMeters, imageUrls));
        }

        [Fact]
        public void Constructor_WithNullImageUrl_ShouldThrow()
        {
            var landlordId = Guid.NewGuid();
            var address = new Address("SomeStreet", "4", "Borås");
            var type = RentalUnitType.Apartment;
            var description = "Some description";
            var numberOfRooms = 3;
            var sizeSquareMeters = 83;
            var imageUrls = new List<WebAddress?>() { null };

            Assert.Throws<ArgumentNullException>(()
                => new RentalUnit(landlordId, address, type, description, numberOfRooms, sizeSquareMeters, imageUrls!));
        }

        [Fact]
        public void ChangeAddress_WithValidAddress_ShouldSucceed()
        {
            var rentalUnit = GetFullRentalUnit();
            var newAddress = new Address("ChangedStreet", "999", "Göteborg");

            rentalUnit.ChangeAddress(newAddress);

            Assert.Equal(newAddress, rentalUnit.Address);
        }

        [Fact]
        public void ChangeAddress_WithNullAddress_ShouldThrow()
        {
            var rentalUnit = GetFullRentalUnit();
            Address? newAddress = null;

            Assert.Throws<ArgumentNullException>(()
                => rentalUnit.ChangeAddress(newAddress!));
        }

        [Fact]
        public void ChangeType_WithValidType_ShouldSucceed()
        {
            var rentalUnit = GetFullRentalUnit();
            var newType = RentalUnitType.Room;

            rentalUnit.ChangeType(newType);

            Assert.Equal(newType, rentalUnit.Type);
        }

        [Fact]
        public void ChangeNumberOfRooms_WithValidValue_ShouldSucceed()
        {
            var rentalUnit = GetFullRentalUnit();
            var newNumberOfRooms = 11;

            rentalUnit.ChangeNumberOfRooms(newNumberOfRooms);

            Assert.Equal(newNumberOfRooms, rentalUnit.NumberOfRooms);
        }

        [Fact]
        public void ChangeNumberOfRooms_WithInvalidValue_ShouldThrow()
        {
            var rentalUnit = GetFullRentalUnit();
            var newNumberOfRooms = 0;

            Assert.Throws<ArgumentOutOfRangeException>(()
                => rentalUnit.ChangeNumberOfRooms(newNumberOfRooms));
        }

        [Fact]
        public void ChangeSizeSquareMeters_WithValidValue_ShouldSucceed()
        {
            var rentalUnit = GetFullRentalUnit();
            var newSizeSquareMeters = 71;

            rentalUnit.ChangeSizeSquareMeters(newSizeSquareMeters);

            Assert.Equal(newSizeSquareMeters, rentalUnit.SizeSquareMeters);
        }

        [Fact]
        public void ChangeSizeSquareMeters_WithInvalidValue_ShouldThrow()
        {
            var rentalUnit = GetFullRentalUnit();
            var newSizeSquareMeters = 0;

            Assert.Throws<ArgumentOutOfRangeException>(()
                => rentalUnit.ChangeSizeSquareMeters(newSizeSquareMeters));
        }

        [Fact]
        public void ReplaceImages_WithValidImageUrls_ShouldSucceed()
        {
            var newImageUrls = new List<WebAddress>() { new("https://newexample.com/newimage/321") };
            var rentalUnit = GetFullRentalUnit();

            rentalUnit.ReplaceImages(newImageUrls);

            Assert.Single(rentalUnit.Images);
            Assert.Equal(newImageUrls[0], rentalUnit.Images[0].Url);
        }

        [Fact]
        public void ReplaceImages_WithNullImageUrls_ShouldThrow()
        {
            List<WebAddress>? newImageUrls = null;
            var rentalUnit = GetFullRentalUnit();
            var oldImage = rentalUnit.Images[0];

            Assert.Throws<ArgumentNullException>(()
                => rentalUnit.ReplaceImages(newImageUrls!));

            Assert.Single(rentalUnit.Images);
            Assert.Equal(oldImage, rentalUnit.Images[0]);
        }

        [Fact]
        public void ReplaceImages_WithEmptyImageUrls_ShouldThrow()
        {
            var newImageUrls = new List<WebAddress>() { };
            var rentalUnit = GetFullRentalUnit();
            var oldImage = rentalUnit.Images[0];

            Assert.Throws<ArgumentException>(()
                => rentalUnit.ReplaceImages(newImageUrls));

            Assert.Single(rentalUnit.Images);
            Assert.Equal(oldImage, rentalUnit.Images[0]);
        }

        [Fact]
        public void ReplaceImages_WithNullImageUrl_ShouldThrow()
        {
            var newImageUrls = new List<WebAddress?>() { null };
            var rentalUnit = GetFullRentalUnit();
            var oldImage = rentalUnit.Images[0];

            Assert.Throws<ArgumentNullException>(()
                => rentalUnit.ReplaceImages(newImageUrls!));

            Assert.Single(rentalUnit.Images);
            Assert.Equal(oldImage, rentalUnit.Images[0]);
        }

        [Fact]
        public void IsOwnedBy_WithCorrectOwner_ShouldReturnTrue()
        {
            var landlordId = Guid.NewGuid();
            var rentalUnit = GetFullRentalUnit(landlordId);

            var result = rentalUnit.IsOwnedBy(landlordId);

            Assert.True(result);
        }

        [Fact]
        public void IsOwnedBy_WithIncorrectOwner_ShouldReturnTrue()
        {
            var rentalUnit = GetFullRentalUnit();
            var landlordId = Guid.NewGuid();

            var result = rentalUnit.IsOwnedBy(landlordId);

            Assert.False(result);
        }

        [Fact]
        public void ChangeDescription_WithValidDescription_ShouldSucceed()
        {
            var rentalUnit = GetFullRentalUnit();
            var newDescription = "This is the new description";

            rentalUnit.ChangeDescription(newDescription);

            Assert.Equal(newDescription, rentalUnit.Description);
        }

        [Fact]
        public void ChangeDescription_WithNullDescription_ShouldThrow()
        {
            var rentalUnit = GetFullRentalUnit();
            string? description = null;

            Assert.Throws<ArgumentNullException>(()
                => rentalUnit.ChangeDescription(description!));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void ChangeDescription_WithEmptyDescription_ShouldThrow(string description)
        {
            var rentalUnit = GetFullRentalUnit();

            Assert.Throws<ArgumentException>(()
                => rentalUnit.ChangeDescription(description));
        }

        private static RentalUnit GetFullRentalUnit(Guid? landlordId = null)
        {
            return new RentalUnit(
                landlordId ?? Guid.NewGuid(),
                new Address("SomeStreet", "4", "Borås"), 
                RentalUnitType.Apartment,
                "Some description", 
                3, 
                83,
                [new("https://example.com/image/123")]
            );
        }
    }
}
