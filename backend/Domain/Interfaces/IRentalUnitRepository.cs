using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IRentalUnitRepository
    {
        Task AddAsync(RentalUnit rentalUnit);
        Task UpdateAsync(RentalUnit rentalUnit);

        Task<RentalUnit?> GetByIdAsync(Guid id);

        Task<IEnumerable<RentalUnit>> GetAllByLandlordIdAsync(Guid landlordId);
    }
}
