using Domain.ValueObjects;

namespace Tests.Unit.ValueObjects
{
    public class PhoneNumberTests
    {
        [Theory]
        [InlineData("0701234567", "0701234567")]
        [InlineData("+46701234567", "+46701234567")]
        [InlineData(" 0701234567 ", "0701234567")]
        [InlineData("070-123 45 67", "0701234567")]
        public void Constructor_WithValidPhoneNumber_ShouldSucceed(string inputValue, string expectedOutput)
        {
            var phoneNumber = new PhoneNumber(inputValue);

            Assert.Equal(expectedOutput, phoneNumber.Value);
        }

        [Fact]
        public void Constructor_WithNullPhoneNumber_ShouldThrow()
        {
            string? phoneNumber = null;

            Assert.Throws<ArgumentNullException>(()
                => new PhoneNumber(phoneNumber!));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("SomeWords")]
        [InlineData("033111111")]
        [InlineData("+4741234567")]
        [InlineData("070123456A")]
        public void Constructor_WithInvalidPhoneNumber_ShouldThrow(string phoneNumber)
        {
            Assert.Throws<ArgumentException>(()  
                => new PhoneNumber(phoneNumber));
        }
    }
}
