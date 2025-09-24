using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMyRentalUnitService
    {
        Task<RentalUnit> CreateAsync(string identityId, RentalUnitDto dto);
        Task<RentalUnit> UpdateAsync(string identityId, Guid id, RentalUnitDto dto);
        Task<RentalUnit?> GetByIdAsync(string identityId, Guid id, Guid landlordId);
        Task<IEnumerable<RentalUnit>> GetAllAsync(string identityId);
    }
}
