using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IListingRepository
    {
        Task AddAsync(Listing listing);
    }
}
