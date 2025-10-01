using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class MyLandlordService(ILandlordRepository repo, IUnitOfWork unitOfWork) : IMyLandlordService
    {
        private readonly ILandlordRepository _repo = repo;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Landlord> CreateAsync(string identityId, LandlordDto dto)
        {
            if (await _repo.GetMyIdAsync(identityId) != Guid.Empty)
                throw new InvalidOperationException($"Landlord with IdentityId '{identityId}' already exists when attempting to create landlord.");

            var landlord = new Landlord(identityId, dto.Name, dto.ProfileImageUrl,
                dto.ContactPhone, dto.ContactEmail);

            await _repo.AddAsync(landlord);
            await _unitOfWork.WriteChangesAsync();

            return landlord;
        }

        public async Task<Guid> GetIdAsync(string identityId)
            => await _repo.GetMyIdAsync(identityId);

        public async Task<LandlordProfile> UpdateProfileAsync(string identityId, LandlordDto dto)
        {
            var landlordId = await _repo.GetMyIdAsync(identityId);

            if (landlordId == Guid.Empty)
                throw new KeyNotFoundException($"Landlord with IdentityId ´{identityId}´ could not be found when attempting to update profile.");

            var profile = await _repo.GetProfileByLandlordId(landlordId) 
                ?? throw new KeyNotFoundException($"LandlordProfile with LandlordId ´{landlordId}´ could not be found when attempting to update profile.");

            profile.SetName(dto.Name);
            profile.SetContactDetails(dto.ContactPhone, dto.ContactEmail);

            if (dto.ProfileImageUrl is not null)
                profile.SetImage(dto.ProfileImageUrl);

            await _repo.UpdateProfileAsync(profile);
            await _unitOfWork.WriteChangesAsync();

            return profile;
        }

        public async Task<LandlordProfile?> GetProfileAsync(string identityId)
        {
            var landlordId = await _repo.GetMyIdAsync(identityId);

            if (landlordId == Guid.Empty)
                throw new KeyNotFoundException($"Landlord with IdentityId '{identityId}' could not be found when attempting to retrieve landlord profile.");

            return await _repo.GetProfileByLandlordId(landlordId);
        }
    }
}
