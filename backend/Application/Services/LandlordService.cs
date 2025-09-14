using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class LandlordService(ILandlordRepository repo) : ILandlordService
    {
        private readonly ILandlordRepository _repo = repo;

        public async Task<Landlord?> GetByIdentityId(string identityId)
        public async Task<Landlord?> GetByIdentityIdAsync(string identityId)
            => await _repo.GetByIdentityIdAsync(identityId);
    }
}
