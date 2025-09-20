using Application.Dtos;
using Domain.ValueObjects;

namespace Api.Requests
{
    public static class Mapping
    {
        public static LandlordDto ToDto(this LandlordRequest request)
        {
            WebAddress? profileImageUrl = null;
            PhoneNumber? contactPhone = null;
            EmailAddress? contactEmail = null;

            if (!string.IsNullOrWhiteSpace(request.ProfileImageUrl))
                profileImageUrl = new WebAddress(request.ProfileImageUrl);

            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
                contactPhone = new PhoneNumber(request.PhoneNumber);

            if (!string.IsNullOrWhiteSpace(request.EmailAddress))
                contactEmail = new EmailAddress(request.EmailAddress);

            return new LandlordDto(request.Name, profileImageUrl, contactPhone, contactEmail);
        }

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
