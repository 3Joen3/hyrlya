using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services
{
    public class LandlordService(ILandlordRepository repo, IUnitOfWork unitOfWork) : ILandlordService
    {
        private readonly ILandlordRepository _repo = repo;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Landlord> CreateAsync(string identityId, string name, 
            string? profileImageUrl = null, string? contactPhone = null, string? contactEmail = null)
        {
            Image? profileImage = null;
            PhoneNumber? phoneNumber = null;
            EmailAddress? emailAddress = null;

            if (!string.IsNullOrWhiteSpace(profileImageUrl))
                profileImage = BuildProfileImage(profileImageUrl, name);

            if (!string.IsNullOrWhiteSpace(contactPhone))
                phoneNumber = new PhoneNumber(contactPhone);

            if (!string.IsNullOrWhiteSpace(contactEmail))
                emailAddress = new EmailAddress(contactEmail);

            var landlord = new Landlord(identityId, name, profileImage, phoneNumber, emailAddress);

            await _repo.AddAsync(landlord);
            await _unitOfWork.WriteChangesAsync();

            return landlord;
        }

        public async Task<Landlord?> GetByIdentityIdAsync(string identityId)
            => await _repo.GetByIdentityIdAsync(identityId);

        public async Task<Guid> GetIdByIdentityIdAsync(string identityId)
            => await _repo.GetIdByIdentityIdAsync(identityId);

        private static Image BuildProfileImage(string profileImageUrl, string profileName)
        {
            var url = new WebAddress(profileImageUrl);
            var altText = $"{profileName} - Profilbild";

            return new Image(url, altText);
        }
    }
}
