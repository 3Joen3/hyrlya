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
            //INTE HAR EN REDAN?

            var landlord = new Landlord(identityId, dto.Name, dto.ProfileImageUrl,
                dto.ContactPhone, dto.ContactEmail);

            await _repo.AddAsync(landlord);
            await _unitOfWork.WriteChangesAsync();

            return landlord;
        }

        public async Task<LandlordProfile> UpdateProfileAsync(string identityId, LandlordDto dto)
        {
            var landlordId = await GetIdByIdentityIdAsync(identityId);
            
            if (landlordId == Guid.Empty)
            {

            }

            var profile = await _repo.GetProfileAsync(landlordId);

            if (profile == null)
            {
                //Do something
            }

            profile.SetName(dto.Name);
            profile.SetContactDetails(dto.ContactPhone, dto.ContactEmail);

            if (dto.ProfileImageUrl is not null)
                profile.SetImage(dto.ProfileImageUrl);

            await _repo.UpdateProfileAsync(profile);
            await _unitOfWork.WriteChangesAsync();

            return profile;
        }

        public async Task<Landlord?> GetWithProfileByIdentityIdAsync(string identityId)
            => await _repo.GetWithProfileByIdentityIdAsync(identityId);

        public async Task<Guid> GetIdByIdentityIdAsync(string identityId)
            => await _repo.GetIdByIdentityIdAsync(identityId);
    }
}
