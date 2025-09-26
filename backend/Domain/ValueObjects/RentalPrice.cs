using Domain.Enums;

namespace Domain.ValueObjects
{
    public record RentalPrice
    {
        ///TEEEEEEEST
        public decimal Amount { get; }
        public ChargeInterval ChargeInterval { get; }

        public RentalPrice(decimal amount, ChargeInterval chargeInterval)
        {
            Amount = amount;
            ChargeInterval = chargeInterval;
        }
    }
}
