using Domain.Entities;

namespace Application.Interfaces
{
    public interface ILandlordService
    {
        Task<Landlord> GetByIdentityId(string identityId);
    }
}
