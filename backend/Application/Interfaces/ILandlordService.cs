using Domain.Entities;
namespace Application.Interfaces
{
    public interface ILandlordService
    {
        Task<Landlord> CreateAsync(string identityId, string name, string? profileImageUrl = null,
            string? contactPhone = null, string? contactEmail = null);

        Task<Landlord?> GetByIdentityIdAsync(string identityId);
    }
}
