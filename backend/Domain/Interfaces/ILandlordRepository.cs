using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILandlordRepository
    {
        Task SaveAsync(Landlord landlord);
        Task<Landlord?> GetByIdentityIdAsync(string identityId);
    }
}
