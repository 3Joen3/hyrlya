using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services
{
    public class MyRentalUnitService(IRentalUnitRepository repo, IUnitOfWork unitOfWork, ILandlordService landlordService) : IMyRentalUnitService
    {
        private readonly IRentalUnitRepository _repo = repo;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        private readonly ILandlordService _landlordService = landlordService;

        public async Task<RentalUnit> CreateAsync(string identityId, RentalUnitDto dto)
        {
            var landlordId = await _landlordService
                .GetIdByIdentityIdAsync(identityId);

            var address = new Address(dto.Street, dto.HouseNumber, dto.City);
            var images = BuildRentalUnitImages(dto.ImageUrls);

            var rentalUnit = new RentalUnit(landlordId, address, 
                dto.Type, dto.NumberOfRooms, dto.SizeSquareMeters, images);

            await _repo.AddAsync(rentalUnit);
            await _unitOfWork.WriteChangesAsync();

            return rentalUnit;
        }

        public async Task<RentalUnit> UpdateAsync(string identityId, Guid id, RentalUnitDto dto)
        {
            var rentalUnit = await GetByIdAsync(identityId, id);

            if (rentalUnit is null)
            {
                //Do something
            }

            var address = new Address(dto.Street, dto.HouseNumber, dto.City);
            rentalUnit.ChangeAddress(address);

            rentalUnit.ChangeType(dto.Type);
            rentalUnit.ChangeNumberOfRooms(dto.NumberOfRooms);
            rentalUnit.ChangeSizeSquareMeters(dto.SizeSquareMeters);

            var images = BuildRentalUnitImages(dto.ImageUrls);
            rentalUnit.ReplaceImages(images);

            await _repo.UpdateAsync(rentalUnit);
            await _unitOfWork.WriteChangesAsync();

            return rentalUnit;
        }

        public async Task<RentalUnit?> GetByIdAsync(string identityId, Guid id)
        {
            var rentalUnit = await _repo.GetByIdAsync(id);

            if (rentalUnit is null)
                return null;

            var landlordId = await _landlordService
                .GetIdByIdentityIdAsync(identityId);

            if (!rentalUnit.IsOwnedBy(landlordId))
            {
                //Do something
            }

            return rentalUnit;
        }

        public async Task<IEnumerable<RentalUnit>> GetAllAsync(string identityId)
        {
            var landlordId = await _landlordService
                .GetIdByIdentityIdAsync(identityId);

            return await _repo.GetAllByLandlordIdAsync(landlordId);
        }
        //Should this method be in RentalUnit?
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
