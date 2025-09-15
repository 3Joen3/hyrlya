using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILandlordRepository
    {
        Task<Landlord> AddAsync(Landlord landlord);
        Task<Landlord?> GetByIdentityIdAsync(string identityId);
        Task<Guid> GetIdByIdentityIdAsync(string identityId);
    }
}
