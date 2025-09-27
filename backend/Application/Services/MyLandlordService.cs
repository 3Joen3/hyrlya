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

        public async Task<Landlord?> GetWithProfileByIdentityIdAsync(string identityId)
            => await _repo.GetWithProfileByIdentityIdAsync(identityId);

        public async Task<Guid> GetIdByIdentityIdAsync(string identityId)
            => await _repo.GetIdByIdentityIdAsync(identityId);
    }
}
