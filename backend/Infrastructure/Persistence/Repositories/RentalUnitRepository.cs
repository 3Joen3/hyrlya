using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class RentalUnitRepository(AppDbContext context) : IRentalUnitRepository
    {
        private readonly AppDbContext _context = context;

        public Task AddAsync(RentalUnit rentalUnit)
        {
            _context.RentalUnits.Add(rentalUnit);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(RentalUnit rentalUnit)
        {
            _context.RentalUnits.Update(rentalUnit);
            return Task.CompletedTask;
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
