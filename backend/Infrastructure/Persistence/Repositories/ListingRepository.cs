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

        public async Task<Listing?> GetWithDetailsByIdAsync(Guid id) 
            => await _context.Listings
                .Include(l => l.RentalUnit)
                .Include(l => l.Landlord)
                .ThenInclude(l => l!.Profile)
                .FirstOrDefaultAsync(l => l.Id == id);

        public async Task<IEnumerable<Listing>> GetAllWithDetailsByLandlordIdAsync(Guid landlordId)
            => await _context.Listings
                .Include(l => l.RentalUnit)
                .Where(l => l.LandlordId == landlordId)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IEnumerable<Listing>> GetPaginatedWithDetailsAsync(int page, int pageSize)
            => await _context.Listings
                .Include(l => l.RentalUnit)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
    }
}
