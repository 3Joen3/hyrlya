using Domain.Entities;

namespace Application.Interfaces
{
    public interface IListingService
    {
        Task<Listing?> GetWithDetailsByIdAsync(Guid id);
        Task<IEnumerable<Listing>> GetWithDetailsPaginatedAsync(int page, int pageSize);
    }
}
