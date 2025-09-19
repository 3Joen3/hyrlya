using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IRentalUnitRepository
    {
        Task AddAsync(RentalUnit rentalUnit);
        Task UpdateAsync(RentalUnit rentalUnit);

        Task<IEnumerable<RentalUnit>> GetAllByLandlordIdAsync(Guid landlordId);
        Task<RentalUnit?> GetByIdAsync(Guid id);
    }
}
