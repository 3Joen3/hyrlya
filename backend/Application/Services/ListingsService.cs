using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ListingsService(IListingRepository repo) : IListingService
    {
        private readonly IListingRepository _repo = repo;

        public async Task<Listing?> GetFullByIdAsync(Guid id) 
            => await _repo.GetFullByIdAsync(id);

        public async Task<IEnumerable<Listing>> GetFullPaginatedAsync(int page, int pageSize)
            => await _repo.GetFullPaginatedAsync(page, pageSize);
    }
}
