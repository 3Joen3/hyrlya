using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IListingRepository
    {
        Task AddAsync(Listing listing);

        Task<IEnumerable<Listing>> GetFullAllByLandlordIdAsync(Guid landlordId);
        Task<IEnumerable<Listing>> GetFullPaginatedAsync(int page, int pageSize);
    }
}
