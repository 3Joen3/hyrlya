using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IRentalUnitService
    {
        Task<RentalUnit> CreateAsync(string identityId, string street, string houseNumber, string city, 
            RentalUnitType type, int rooms, int sizeSquareMeters, IEnumerable<string> imageUrls);
        Task<IEnumerable<RentalUnit>> GetAllByLandlordIdAsync(Guid landlordId);
    }
}
