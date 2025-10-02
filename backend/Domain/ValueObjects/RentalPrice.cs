using Domain.Enums;

namespace Domain.ValueObjects
{
    public record RentalPrice
    {
        public decimal Amount { get; }
        public ChargeInterval ChargeInterval { get; }

        public RentalPrice(decimal amount, ChargeInterval chargeInterval)
        {
            if (amount < 1)
                throw new ArgumentException("Amount can't be under 1.");

            Amount = amount;
            ChargeInterval = chargeInterval;
        }
    }
}
