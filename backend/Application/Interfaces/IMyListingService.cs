using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMyListingService
    {
        Task<Listing> CreateAsync(string identityId, ListingDto dto);
    }
}
