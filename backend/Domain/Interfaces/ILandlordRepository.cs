using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILandlordRepository
    {
        Task<Landlord> SaveAsync(Landlord landlord);
        Task<Landlord?> GetByIdentityIdAsync(string identityId);
    }
}
