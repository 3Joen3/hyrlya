using Api.Responses.Common;
using Domain.Entities;

namespace Api.Responses.Landlords
{
    public class LandlordProfileDetails(LandlordProfile profile)
    {
        public string Name { get; } = profile.Name;
        public ImageResponse? Image { get; } = profile.Image is not null ? new ImageResponse(profile.Image) : null;
        public string? Phone { get; } = profile.PhoneNumber?.Value;
        public string? Email { get; } = profile.EmailAddress?.Value;
    }
}
