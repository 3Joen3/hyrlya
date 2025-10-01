using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMyLandlordService
    {
        Task<Landlord> CreateAsync(string identityId, LandlordDto dto);
        Task<Guid> GetIdAsync(string identityId);

        Task<LandlordProfile> UpdateProfileAsync(string identityId, LandlordDto dto);
        Task<LandlordProfile?> GetProfileAsync(string identityId); 
    }
}
