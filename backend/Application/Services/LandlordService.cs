using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class LandlordService : ILandlordService
    {
        public Task<Landlord> GetByIdentityId(string identityId)
        {
            throw new NotImplementedException();
        }
    }
}
