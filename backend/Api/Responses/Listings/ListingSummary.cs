using Api.Responses.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Responses.Listings
{
    public class ListingSummary(Listing listing)
    {
        public Guid Id { get; } = listing.Id;
        public ImageResponse Image { get; } = listing.RentalUnit is null ? throw new ArgumentException("RentalUnit must be loaded") : new ImageResponse(listing.RentalUnit.Images[0]);
        public Address Address { get; } = listing.RentalUnit.Address;
        public RentalPrice RentalPrice { get; } = listing.RentalPrice;  
    }
}
