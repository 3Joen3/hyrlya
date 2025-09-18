using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services
{
    public class RentalUnitService(IRentalUnitRepository repo, ILandlordService landlordService) : IRentalUnitService
    {
        private readonly IRentalUnitRepository _repo = repo;
        private readonly ILandlordService _landlordService = landlordService;

        public async Task<RentalUnit> CreateAsync(string identityId, string street, string houseNumber, string city, 
            RentalUnitType type, int rooms, int sizeSquareMeters, IEnumerable<string> imageUrls)
        {
            var landlordId = await _landlordService.GetIdByIdentityIdAsync(identityId);

            if (landlordId == Guid.Empty)
                return null;

            var address = new Address(street, houseNumber, city);
            var images = BuildRentalUnitImages(imageUrls);

            var rentalUnit = new RentalUnit(landlordId, address, type, rooms, sizeSquareMeters, images);
            return await _repo.AddAsync(rentalUnit);
        }

        public async Task<IEnumerable<RentalUnit>> GetAllByIdentityIdAsync(string identityId)
        {
            var landlordId = await _landlordService.GetIdByIdentityIdAsync(identityId);

            if (landlordId == Guid.Empty)
                return null;

            return await _repo.GetAllByLandlordIdAsync(landlordId);
        }

        private static IEnumerable<Image> BuildRentalUnitImages(IEnumerable<string> imageUrls)
        {
            var index = 1;
            foreach (var imageUrl in imageUrls)
            {
                var url = new WebAddress(imageUrl);
                var alt = $"Bostadsannons – bild {index}";

                yield return new Image(url, alt);
                index++;
            }
        }
    }
}
