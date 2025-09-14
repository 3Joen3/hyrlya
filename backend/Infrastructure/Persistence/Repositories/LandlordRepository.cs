using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class LandlordRepository(AppDbContext context) : ILandlordRepository
    {
        private readonly AppDbContext _context = context;

        public async Task SaveAsync(Landlord landlord)
        {
            _context.Landlords.Add(landlord);
            await _context.SaveChangesAsync();
        }

        public async Task<Landlord?> GetByIdentityIdAsync(string identityId)
            => await _context.Landlords.FirstOrDefaultAsync(l => l.IdentityId == identityId);
    }
}
