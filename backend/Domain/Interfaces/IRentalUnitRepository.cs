using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IRentalUnitRepository
    {
        Task<RentalUnit> AddAsync(RentalUnit rentalUnit);
    }
}
