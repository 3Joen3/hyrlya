using Domain.Entities;

namespace Api.Responses.Landlords
{
    public class LandlordDetails(Landlord landlord)
    {
        public Guid Id { get; } = landlord.Id;
        public LandlordProfileDetails Profile { get; } = new LandlordProfileDetails(landlord.Profile);
    }
}
