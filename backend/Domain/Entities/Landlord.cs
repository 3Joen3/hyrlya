using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Landlord : Entity
    {
        private readonly List<RentalUnit> _rentalUnits = [];
        public IReadOnlyList<RentalUnit> RentalUnits => _rentalUnits.AsReadOnly();

        public string IdentityId { get; private set; }
        public LandlordProfile Profile { get; private set; }

        public Landlord(string identityId, string profileName, WebAddress? profileImageUrl = null,
            PhoneNumber? profilePhone = null, EmailAddress? profileEmail = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(identityId);

            IdentityId = identityId;
            Profile = new LandlordProfile(profileName, this, profileImageUrl, profilePhone, profileEmail);
        }

        private Landlord()
        {
            IdentityId = default!;
            Profile = default!;
        }
    }
}
