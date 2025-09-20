using Domain.ValueObjects;

namespace Application.Dtos
{
    public record LandlordDto(
        string Name,
        WebAddress? ProfileImageUrl,
        PhoneNumber? ContactPhone,
        EmailAddress? ContactEmail
    );
}
