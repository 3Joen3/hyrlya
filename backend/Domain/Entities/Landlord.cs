using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Landlord : Entity
    {
        private readonly List<RentalUnit> _rentalUnits = [];

        public string IdentityId { get; private set; }
        public LandlordProfile Profile { get; private set; }
        public IReadOnlyList<RentalUnit> RentalUnits => _rentalUnits.AsReadOnly();

        public Landlord(string identityId, string name, Image? image = null,
            PhoneNumber? contactPhone = null, EmailAddress? contactEmail = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(identityId);

            IdentityId = identityId;
            Profile = new LandlordProfile(name, this, image, contactPhone, contactEmail);
        }

        private Landlord()
        {
            IdentityId = default!;
            Profile = default!;
        }
    }
}
