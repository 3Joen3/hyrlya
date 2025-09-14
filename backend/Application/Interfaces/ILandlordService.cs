using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Interfaces
{
    public interface ILandlordService
    {
        Task<Landlord> CreateAsync(string identityId, string name, Image? image = null,
            PhoneNumber? contactPhone = null, EmailAddress? contactEmail = null);

        Task<Landlord?> GetByIdentityIdAsync(string identityId);
    }
}
