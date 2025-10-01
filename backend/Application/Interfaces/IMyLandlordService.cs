using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMyLandlordService
    {
        Task<Landlord> CreateAsync(string identityId, LandlordDto dto);
        Task<LandlordProfile> UpdateProfileAsync(string identityId, LandlordDto dto);
        Task<Landlord?> GetWithProfileByIdentityIdAsync(string identityId);
        Task<Guid> GetIdByIdentityIdAsync(string identityId);
    }
}
