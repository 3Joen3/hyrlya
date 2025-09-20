using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services
{
    public class MyLandlordService(ILandlordRepository repo, IUnitOfWork unitOfWork) : IMyLandlordService
    {
        private readonly ILandlordRepository _repo = repo;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Landlord> CreateAsync(string identityId, LandlordDto dto)
        {
            //INTE HAR EN REDAN?
            Image? profileImage = null;

            if (dto.ProfileImageUrl is not null)
                profileImage = BuildProfileImage(dto.ProfileImageUrl, dto.Name);

            var landlord = new Landlord(identityId, dto.Name, profileImage, dto.ContactPhone, dto.ContactEmail);

            await _repo.AddAsync(landlord);
            await _unitOfWork.WriteChangesAsync();

            return landlord;
        }

        public async Task<Landlord?> GetByIdentityIdAsync(string identityId)
            => await _repo.GetByIdentityIdAsync(identityId);

        public async Task<Guid> GetIdByIdentityIdAsync(string identityId)
            => await _repo.GetIdByIdentityIdAsync(identityId);

        //MOVE THIS TO DOMAIN
        private static Image BuildProfileImage(WebAddress imageUrl, string profileName)
        {
            var altText = $"{profileName} - Profilbild";

            return new Image(imageUrl, altText);
        }
    }
}
