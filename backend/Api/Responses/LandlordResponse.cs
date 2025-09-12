using Domain.Entities;

namespace Api.Responses
{
    public record LandlordResponse
    {
        public LandlordProfileResponse Profile { get; }

        public LandlordResponse(Landlord landlord)
        {
            Profile = new LandlordProfileResponse(landlord.Profile.Name);
        }
    }

    public record LandlordProfileResponse(string Name);
}
