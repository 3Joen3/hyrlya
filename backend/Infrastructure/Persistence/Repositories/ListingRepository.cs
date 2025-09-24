using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class ListingRepository(AppDbContext context) : IListingRepository
    {
        private readonly AppDbContext _context = context;

        public Task AddAsync(Listing listing)
        {
            _context.Listings.Add(listing);
            return Task.CompletedTask;
        }
    }
}
