using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Persistence.Repositories
{
    public class RentalUnitRepository(AppDbContext context) : IRentalUnitRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<RentalUnit> AddAsync(RentalUnit rentalUnit)
        {
            _context.RentalUnits.Add(rentalUnit);
            await _context.SaveChangesAsync();

            return rentalUnit;
        }

        public async Task<IEnumerable<RentalUnit>> GetAllByLandlordIdAsync(Guid landlordId)
        {
            return await _context.RentalUnits
                .Where(r => r.LandlordId == landlordId)
                .ToListAsync();
        }

        public async Task<RentalUnit?> GetByIdAsync(Guid id)
            => await _context.RentalUnits.FirstOrDefaultAsync(r => r.Id == id);
    }
}
