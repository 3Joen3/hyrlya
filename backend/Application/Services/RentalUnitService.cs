using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services
{
    public class RentalUnitService(IRentalUnitRepository repo, ILandlordService landlordService) : IRentalUnitService
    {
        private readonly IRentalUnitRepository _repo = repo;
        private readonly ILandlordService _landlordService = landlordService;

        public async Task<RentalUnit> CreateAsync(string identityId, IEnumerable<string> imageUrls, 
            string street, string houseNumber, string city)
        {
            var landlordId = await _landlordService.GetIdByIdentityIdAsync(identityId);

            if (landlordId == Guid.Empty)
                return null;

            var images = BuildRentalUnitImages(imageUrls);
            var address = new Address(street, houseNumber, city);

            var rentalUnit = new RentalUnit(images, address, landlordId);

            return await _repo.AddAsync(rentalUnit);
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
