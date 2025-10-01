using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ListingService(IListingRepository repo) : IListingService
    {
        private readonly IListingRepository _repo = repo;

        public async Task<Listing?> GetWithDetailsByIdAsync(Guid id) 
            => await _repo.GetFullByIdAsync(id);

        public async Task<IEnumerable<Listing>> GetWithDetailsPaginatedAsync(int page, int pageSize)
            => await _repo.GetFullPaginatedAsync(page, pageSize);
    }
}
