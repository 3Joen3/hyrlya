using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class LandlordRepository(AppDbContext context) : ILandlordRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Landlord> AddAsync(Landlord landlord)
        {
            _context.Landlords.Add(landlord);
            await _context.SaveChangesAsync();

            return landlord;
        }

        public async Task<Landlord?> GetByIdentityIdAsync(string identityId)
            => await _context.Landlords.Include(l => l.Profile)
            .SingleOrDefaultAsync(l => l.IdentityId == identityId);

        public async Task<Guid> GetIdByIdentityIdAsync(string identityId)
            => await _context.Landlords.Where(l => l.IdentityId == identityId)
            .Select(l => l.Id)
            .SingleOrDefaultAsync();
    }
}
