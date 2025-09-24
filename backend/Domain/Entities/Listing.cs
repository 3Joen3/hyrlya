using Domain.Enums;

namespace Domain.Entities
{
    public class Listing : Entity
    {
        public Guid LandlordId { get; private set; }
        public Landlord? Landlord { get; private set; }

        public RentalUnit RentalUnit { get; private set; }
        public RentalType RentalType { get; set; }

        public Listing(Guid landlordId, RentalUnit rentalUnit, RentalType rentalType) 
        {
            LandlordId = SetLandlordId(landlordId);
            RentalUnit = SetRentalUnit(rentalUnit);
            RentalType = rentalType;
        }

        private Listing() 
        {
            RentalUnit = default!;
        }

        private static Guid SetLandlordId(Guid landlordId)
        {
            if (landlordId == Guid.Empty)
                throw new ArgumentException("LandlordId can't be empty.", nameof(landlordId));

            return landlordId;
        }

        private static RentalUnit SetRentalUnit(RentalUnit rentalUnit)
        {
            ArgumentNullException.ThrowIfNull(rentalUnit);
            return rentalUnit;
        }
    }
}
