using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILandlordRepository
    {
        Task<Landlord?> GetByIdentityIdAsync(string identityId);
    }
}
