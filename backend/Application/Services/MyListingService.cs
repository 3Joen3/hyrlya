using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class MyListingService(IListingRepository repo, IUnitOfWork unitOfWork, 
        ILandlordRepository landlordRepository, IRentalUnitRepository rentalUnitRepo) : IMyListingService
    {
        private readonly IListingRepository _repo = repo;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        private readonly ILandlordRepository _landlordRepository = landlordRepository;
        private readonly IRentalUnitRepository _rentalUnitRepo = rentalUnitRepo;

        public async Task<Listing> CreateAsync(string identityId, ListingDto dto)
        {
            var landlordId = await _landlordRepository
                .GetMyIdAsync(identityId);

            if (landlordId == Guid.Empty)
                throw new KeyNotFoundException($"Landlord with IdentityId '{identityId}' could not be found when attempting to create listing.");

            var rentalUnit = await _rentalUnitRepo
                .GetByIdAsync(dto.RentalUnitId) 
                ?? throw new KeyNotFoundException($"RentalUnit with Id '{dto.RentalUnitId}' could not be found when attempting to create listing.");

            if (!rentalUnit.IsOwnedBy(landlordId))
                throw new UnauthorizedAccessException($"RentalUnit with Id '{rentalUnit.Id}' is not owned by Landlord with Id '{landlordId}' when attempting to create listing.");

            var listing = new Listing(landlordId, rentalUnit.Id, dto.RentalPrice, dto.LandlordNote);

            await _repo.AddAsync(listing);
            await _unitOfWork.WriteChangesAsync();

            return listing;
        }

        public async Task<IEnumerable<Listing>> GetAllWithDetailsAsync(string identityId)
        {
            var landlordId = await _landlordRepository
                .GetMyIdAsync(identityId);

            if (landlordId == Guid.Empty)
                throw new KeyNotFoundException($"Landlord with IdentityId '{identityId}' could not be found when attempting to retrieve all listings.");

            return await _repo.GetFullAllByLandlordIdAsync(landlordId);
        }
    }
}
