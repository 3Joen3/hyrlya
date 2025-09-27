using Api.Responses.Common;
using Api.Responses.Landlords;
using Domain.Entities;

namespace Api.Responses.Listings
{
    public class ListingDetails(Listing listing)
    {
        public IEnumerable<ImageResponse> Images { get; } = listing.RentalUnit.Images.Select(img => new ImageResponse(img));
        public LandlordProfileDetails Landlord { get; } = new LandlordProfileDetails(listing.Landlord.Profile);
    }
}
