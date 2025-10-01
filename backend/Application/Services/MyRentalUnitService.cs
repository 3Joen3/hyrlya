using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class MyRentalUnitService(IRentalUnitRepository repo, IUnitOfWork unitOfWork, 
        IMyLandlordService myLandlordService) : IMyRentalUnitService
    {
        private readonly IRentalUnitRepository _repo = repo;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        private readonly IMyLandlordService _myLandlordService = myLandlordService;

        public async Task<RentalUnit> CreateAsync(string identityId, RentalUnitDto dto)
        {
            var landlordId = await _myLandlordService
                .GetIdAsync(identityId);

            if (landlordId == Guid.Empty)
                throw new KeyNotFoundException($"Landlord with IdentityId ´{identityId}´ could not be found when attempting to create rental unit.");

            var rentalUnit = new RentalUnit(landlordId, dto.Address, dto.Type, dto.Description,
                dto.NumberOfRooms, dto.SizeSquareMeters, dto.ImageUrls);

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

            rentalUnit.SetAddress(dto.Address);
            rentalUnit.SetType(dto.Type);
            rentalUnit.SetDescription(dto.Description);
            rentalUnit.SetNumberOfRooms(dto.NumberOfRooms);
            rentalUnit.SetSizeSquareMeters(dto.SizeSquareMeters);
            rentalUnit.SetImages(dto.ImageUrls);

            await _repo.UpdateAsync(rentalUnit);
            await _unitOfWork.WriteChangesAsync();

            return rentalUnit;
        }

        public async Task<RentalUnit?> GetByIdAsync(string identityId, Guid id)
        {
            var rentalUnit = await _repo.GetByIdAsync(id);

            if (rentalUnit is null)
                return null;

            var landlordId = await _myLandlordService
                .GetIdByIdentityIdAsync(identityId);
                
            if (!rentalUnit.IsOwnedBy(landlordId))
            {
                //Do something
            }

            return rentalUnit;
        }

        public async Task<RentalUnit?> GetByIdAsync(Guid landlordId, Guid id)
        {
            var rentalUnit = await _repo.GetByIdAsync(id);

            if (rentalUnit is null)
                return null;

            if (!rentalUnit.IsOwnedBy(landlordId))
            {
                //Do Something
            }

            return rentalUnit;
        }

        public async Task<IEnumerable<RentalUnit>> GetAllAsync(string identityId)
        {
            var landlordId = await _myLandlordService
                .GetIdByIdentityIdAsync(identityId);

            return await _repo.GetAllByLandlordIdAsync(landlordId);
        }
    }
}
