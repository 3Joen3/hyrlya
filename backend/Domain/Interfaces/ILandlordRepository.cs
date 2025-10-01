using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILandlordRepository
    {
        Task AddAsync(Landlord landlord);
        Task UpdateProfileAsync(LandlordProfile landlordProfile);

        Task<Landlord?> GetWithProfileByIdentityIdAsync(string identityId);
        Task<Guid> GetIdByIdentityIdAsync(string identityId);
        Task<LandlordProfile?> GetProfileAsync(Guid landlordId);
    }
}
