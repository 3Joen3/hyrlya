using Api.Responses.Common;
using Domain.Entities;

namespace Api.Responses.Listings
{
    public class ListingDetails(Listing listing)
    {
        public IEnumerable<ImageResponse> Images { get; } = listing.RentalUnit.Images.Select(img => new ImageResponse(img));
    }
}
