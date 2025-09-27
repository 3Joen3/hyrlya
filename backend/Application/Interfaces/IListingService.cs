using Domain.Entities;

namespace Application.Interfaces
{
    public interface IListingService
    {
        Task<IEnumerable<Listing>> GetFullPaginatedAsync(int page, int pageSize);
    }
}
