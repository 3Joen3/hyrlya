using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Listing : Entity
    {
        public RentalPeriod RentalPeriod { get; private set; }+
        
        public Guid LandlordId { get; private set; }
        public Landlord? Landlord { get; private set; }

        public Listing(Guid landlordId)
        {
            LandlordId = SetLandlordId(landlordId);
        }

        private static Guid SetLandlordId(Guid landlordId)
        {
            if (landlordId == Guid.Empty)
                throw new ArgumentException("LandlordId can't be empty.", nameof(landlordId));

            return landlordId;
        }
    }
}
