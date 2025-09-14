using Domain.Entities;

namespace Application.Interfaces
{
    public interface ILandlordService
    {
        Task<Landlord?> GetByIdentityId(string identityId);
        Task<Landlord?> GetByIdentityIdAsync(string identityId);
    }
}
