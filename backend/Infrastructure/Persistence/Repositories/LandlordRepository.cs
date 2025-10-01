using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class LandlordRepository(AppDbContext context) : ILandlordRepository
    {
        private readonly AppDbContext _context = context;

        public Task AddAsync(Landlord landlord)
        {
            _context.Landlords.Add(landlord);
            return Task.CompletedTask;
        }

        public async Task<Guid> GetMyIdAsync(string identityId)
            => await _context.Landlords
            .Where(l => l.IdentityId == identityId)
            .Select(l => l.Id)
            .SingleOrDefaultAsync();

        public Task UpdateProfileAsync(LandlordProfile landlordProfile)
        {
            _context.LandlordProfiles.Update(landlordProfile);
            return Task.CompletedTask;
        }

        public Task<LandlordProfile?> GetProfileByLandlordId(Guid landlordId)
            => _context.LandlordProfiles
            .SingleOrDefaultAsync(p => p.LandlordId == landlordId);
    }
}
