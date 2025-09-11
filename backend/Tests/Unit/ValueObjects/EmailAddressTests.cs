using Domain.ValueObjects;

namespace Tests.Unit.ValueObjects
{
    public class EmailAddressTests
    {
        [Fact]
        public void Constructor_WithValidEmailAddress_ShouldSucceed()
        {
            var value = "random@example.com";

            var email = new EmailAddress(value);

            Assert.Equal(value, email.Value);
        }

        [Fact]
        public void Constructor_WithNullEmailAddress_ShouldThrow()
        {
            string? emailAddress = null;

            Assert.Throws<ArgumentNullException>(()
                => new EmailAddress(emailAddress!));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("SomeWords")]
        [InlineData("randomexample.com")]
        [InlineData("@example.com")]
        public void Constructor_WithInvalidEmailAddress_ShouldThrow(string emailAddress)
        {
            Assert.Throws<ArgumentException>(()
                => new EmailAddress(emailAddress));
        }
    }
}
