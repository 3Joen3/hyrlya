using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILandlordRepository
    {
        Task AddAsync(Landlord landlord);

        Task<Landlord?> GetWithProfileByIdentityIdAsync(string identityId);
        Task<Guid> GetIdByIdentityIdAsync(string identityId);
    }
}
