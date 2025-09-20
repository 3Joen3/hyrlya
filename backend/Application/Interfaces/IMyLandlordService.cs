using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMyLandlordService
    {
        Task<Landlord> CreateAsync(string identityId, LandlordDto dto);
        Task<Landlord?> GetByIdentityIdAsync(string identityId);
        Task<Guid> GetIdByIdentityIdAsync(string identityId);
    }
}
