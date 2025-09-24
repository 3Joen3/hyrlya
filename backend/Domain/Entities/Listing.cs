using Domain.Enums;

namespace Domain.Entities
{
    public class Listing : Entity
    {
        public Guid LandlordId { get; private set; }
        public Landlord? Landlord { get; private set; }

        public Guid RentalUnitId { get; private set; }
        public RentalUnit? RentalUnit { get; private set; }

        public RentalType RentalType { get; set; }

        public Listing(Guid landlordId, Guid rentalUnitId, RentalType rentalType) 
        {
            LandlordId = SetLandlordId(landlordId);
            RentalUnitId = SetRentalUnitId(rentalUnitId);
            RentalType = rentalType;
        }

        private static Guid SetLandlordId(Guid landlordId)
        {
            if (landlordId == Guid.Empty)
                throw new ArgumentException("LandlordId can't be empty.", nameof(landlordId));

            return landlordId;
        }

        private static Guid SetRentalUnitId(Guid rentalUnitId)
        {
            if (rentalUnitId == Guid.Empty)
                throw new ArgumentException("RentalUnitId can't be empty.", nameof(rentalUnitId));

            return rentalUnitId;
        }

        private Listing()
        {
            RentalUnit = default!;
        }
    }
}
