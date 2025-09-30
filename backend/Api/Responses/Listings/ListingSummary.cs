using Api.Responses.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Responses.Listings
{
    public class ListingSummary
    {
        public Guid Id { get; }
        public Address Address { get; }
        public ImageResponse Image { get; }
        public RentalPriceResponse RentalPrice { get; }

        public ListingSummary(Listing listing)
        {
            if (listing.RentalUnit is null)
                throw new ArgumentException("RentalUnit must be loaded");

            Id = listing.Id;
            Address = listing.RentalUnit.Address;
            Image = new ImageResponse(listing.RentalUnit.Images[0]);
            RentalPrice = new RentalPriceResponse(listing.RentalPrice);
        }
    }
}
