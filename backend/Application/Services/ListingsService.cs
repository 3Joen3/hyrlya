using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ListingsService(IListingRepository repo) : IListingService
    {
        private readonly IListingRepository _repo = repo;

        public async Task<IEnumerable<Listing>> GetPaginatedAsync(int page, int pageSize)
        {
            var listings = await _repo.GetPaginatedAsync(page, pageSize);
            return listings;
        }
    }
}
