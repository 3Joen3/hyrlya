using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Application.Services
{
    public class MyListingService(IListingRepository repo, IUnitOfWork unitOfWork, 
        IMyLandlordService myLandlordService, IMyRentalUnitService myRentalUnitService) : IMyListingService
    {
        private readonly IListingRepository _repo = repo;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        private readonly IMyLandlordService _myLandlordService = myLandlordService;
        private readonly IMyRentalUnitService _myRentalUnitService = myRentalUnitService;

        public async Task<Listing> CreateAsync(string identityId, ListingDto dto)
        {
            var landlordId = await _myLandlordService
                .GetIdByIdentityIdAsync(identityId);

            var rentalUnit = await _myRentalUnitService
                .GetByIdAsync(landlordId, dto.RentalUnitId);

            if (rentalUnit == null)
            {
                //Do Something
            }

            var listing = new Listing(landlordId, rentalUnit.Id, dto.RentalPrice);

            await _repo.AddAsync(listing);
            await _unitOfWork.WriteChangesAsync();

            return listing;
        }

        public async Task<IEnumerable<Listing>> GetAllAsync(string identityId)
        {
            var landlordId = await _myLandlordService
                .GetIdByIdentityIdAsync(identityId);

            return await _repo.GetAllByLandlordIdAsync(landlordId);
        }
    }
}
