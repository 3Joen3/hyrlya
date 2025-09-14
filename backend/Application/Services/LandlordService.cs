using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services
{
    public class LandlordService(ILandlordRepository repo) : ILandlordService
    {
        private readonly ILandlordRepository _repo = repo;

        public async Task<Landlord> CreateAsync(string identityId, string name, Image? image = null,
            PhoneNumber? contactPhone = null, EmailAddress? contactEmail = null)
        {
            var landlord = new Landlord(identityId, name, image, contactPhone, contactEmail);
            return await _repo.SaveAsync(landlord);
        }

        public async Task<Landlord?> GetByIdentityIdAsync(string identityId)
            => await _repo.GetByIdentityIdAsync(identityId);
    }
}
