using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IListingRepository
    {
        Task AddAsync(Listing listing);
        Task<Listing?> GetWithDetailsByIdAsync(Guid id);
        Task<IEnumerable<Listing>> GetAllWithDetailsByLandlordIdAsync(Guid landlordId);
        Task<IEnumerable<Listing>> GetPaginatedWithDetailsAsync(int page, int pageSize);
    }
}
