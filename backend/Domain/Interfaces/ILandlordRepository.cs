using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILandlordRepository
    {
        Task AddAsync(Landlord landlord);
        Task<Guid> GetMyIdAsync(string identityId);

        Task UpdateProfileAsync(LandlordProfile landlordProfile);
        Task<LandlordProfile?> GetProfileByLandlordId(Guid landlordId);
    }
}
