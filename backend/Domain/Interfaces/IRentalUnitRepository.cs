using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IRentalUnitRepository
    {
        Task<RentalUnit> AddAsync(RentalUnit rentalUnit);
        Task<IEnumerable<RentalUnit>> GetAllByLandlordIdAsync(Guid landlordId);
        Task<RentalUnit?> GetByIdAsync(Guid id);
    }
}
