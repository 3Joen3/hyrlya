using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Listing>> GetAllByLandlordIdAsync(Guid landlordId)
        {
            return await _context.Listings
                .Where(l => l.LandlordId == landlordId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Listing>> GetPaginatedAsync(int page, int pageSize)
        {
            return await _context.Listings
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
