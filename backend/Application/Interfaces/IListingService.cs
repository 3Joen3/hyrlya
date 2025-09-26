using Domain.Entities;

namespace Application.Interfaces
{
    public interface IListingService
    {
        Task<IEnumerable<Listing>> GetPaginatedAsync(int page, int pageSize);
    }
}
