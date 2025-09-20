using Application.Dtos;
using Domain.ValueObjects;

namespace Api.Requests
{
    public static class Mapping
    {
        public static RentalUnitDto ToDto(this RentalUnitRequest request)
        {
            var address = new Address(request.Address.Street, 
                request.Address.HouseNumber, request.Address.City);

            var imageUrls = request.ImageUrls
                .Select(url => new WebAddress(url));

            return new RentalUnitDto(address, request.Type, 
                request.NumberOfRooms, request.SizeSquareMeters, imageUrls);
        }
    }
}
