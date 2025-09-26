using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Listing : Entity
    {
        public Guid LandlordId { get; private set; }
        public Landlord? Landlord { get; private set; }

        public Guid RentalUnitId { get; private set; }
        public RentalUnit? RentalUnit { get; private set; }

        public RentalPrice RentalPrice { get; private set; }

        public Listing(Guid landlordId, Guid rentalUnitId, RentalPrice rentalPrice) 
        {
            LandlordId = SetLandlordId(landlordId);
            RentalUnitId = SetRentalUnitId(rentalUnitId);
            RentalPrice = SetRentalPrice(rentalPrice);
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

        private static RentalPrice SetRentalPrice(RentalPrice rentalPrice)
        {
            ArgumentNullException.ThrowIfNull(rentalPrice);
            return rentalPrice;
        }

        private Listing()
        {
            RentalUnit = default!;
            RentalPrice = default!;
        }
    }
}
