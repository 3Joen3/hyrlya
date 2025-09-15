using Domain.ValueObjects;

namespace Tests.Unit.ValueObjects
{
    public class AddressTests
    {
        [Fact]
        public void Constructor_WithFullValidParameters_ShouldSucceed()
        {
            var street = "SomeStreet";
            var houseNumber = "123";
            var city = "Borås";

            var address = new Address(street, houseNumber, city);

            Assert.Equal(street, address.Street);
            Assert.Equal(houseNumber, address.HouseNumber);
            Assert.Equal(city, address.City);
        }

        [Fact]
        public void Constructor_WithNullStreet_ShouldThrow()
        {
            string? street = null!;
            var houseNumber = "123";
            var city = "Borås";

            Assert.Throws<ArgumentNullException>(()
                => new Address(street!, houseNumber, city));
        }

        [Fact]
        public void Constructor_WithNullCity_ShouldThrow()
        {
            var street = "SomeStreet";
            var houseNumber = "123";
            string? city = null;

            Assert.Throws<ArgumentNullException>(()
                => new Address(street, houseNumber, city!));
        }

        [Fact]
        public void Constructor_WithNullHouseNumber_ShouldThrow()
        {
            var street = "SomeStreet";
            string? houseNumber = null;
            var city = "Borås";

            Assert.Throws<ArgumentNullException>(()
                => new Address(street, houseNumber!, city!));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WithInvalidStreet_ShouldThrow(string street)
        {
            var houseNumber = "123";
            var city = "Borås";

            Assert.Throws<ArgumentException>(()
                => new Address(street, houseNumber, city));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WithInvalidHouseNumber_ShouldThrow(string houseNumber)
        {
            var street = "SomeStreet";
            var city = "Borås";

            Assert.Throws<ArgumentException>(()
                => new Address(street, houseNumber, city));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WithInvalidCity_ShouldThrow(string city)
        {
            var street = "SomeStreet";
            var houseNumber = "123";

            Assert.Throws<ArgumentException>(()
                => new Address(street, houseNumber, city));
        }
    }
}
