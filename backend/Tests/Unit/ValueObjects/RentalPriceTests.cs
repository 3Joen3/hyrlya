using Domain.Enums;
using Domain.ValueObjects;

namespace Tests.Unit.ValueObjects
{
    public class RentalPriceTests
    {
        [Fact]
        public void Constructor_WithFullValidParameters_ShouldSucceed()
        {
            var amount = 999;
            var chargeInterval = ChargeInterval.Daily;

            var rentalPrice = new RentalPrice(amount, chargeInterval);

            Assert.Equal(amount, rentalPrice.Amount);
            Assert.Equal(chargeInterval, rentalPrice.ChargeInterval);
        }

        [Fact]
        public void Constructor_WithNegativeAmount_ShouldThrow()
        {
            var amount = -1;
            var chargeInterval = ChargeInterval.Daily;

            Assert.Throws<ArgumentException>(() 
                => new RentalPrice(amount, chargeInterval));
        }
    }
}
