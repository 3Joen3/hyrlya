using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRentalUnitService
    {
        Task<RentalUnit> CreateAsync(string identityId, IEnumerable<string> imageUrls, 
            string street, string houseNumber, string city);
    }
}
