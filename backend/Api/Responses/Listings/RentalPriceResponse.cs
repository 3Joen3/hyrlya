using Domain.ValueObjects;

namespace Api.Responses.Listings
{
    public class RentalPriceResponse(RentalPrice rentalPrice)
    {
        public decimal Amount { get; } = rentalPrice.Amount;
        public string ChargeInterval { get; } = rentalPrice.ChargeInterval.ToString();
    }
}
