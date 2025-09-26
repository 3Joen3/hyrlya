using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Responses.Listings
{
    public class ListingSummary(Listing listing)
    {
        public Guid Id { get; } = listing.Id;
    }
}
