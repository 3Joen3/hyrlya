using Domain.Entities;

namespace Api.Responses.Landlords
{
    public class LandlordDetails(Landlord landlord)
    {
        public LandlordProfileDetails Profile { get; } = new LandlordProfileDetails(landlord.Profile);
    }

    public class LandlordProfileDetails(LandlordProfile profile)
    {
        public string Name { get; } = profile.Name;
    }
}
