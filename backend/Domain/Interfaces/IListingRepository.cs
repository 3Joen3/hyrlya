using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IListingRepository
    {
        Task AddAsync(Listing listing);

        Task<IEnumerable<Listing>> GetAllByLandlordIdAsync(Guid landlordId);
        Task<IEnumerable<Listing>> GetPaginatedAsync(int page, int pageSize);
    }
}
