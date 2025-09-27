using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILandlordRepository
    {
        Task AddAsync(Landlord landlord);

        Task<Landlord?> GetByIdentityIdAsync(string identityId);

        Task<LandlordProfile?> GetProfileByLandlordIdAsync(Guid landlordId);

        Task<Guid> GetIdByIdentityIdAsync(string identityId);
    }
}
