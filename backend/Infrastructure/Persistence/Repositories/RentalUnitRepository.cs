using Domain.Entities;
using Domain.Interfaces;

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
    }
}
