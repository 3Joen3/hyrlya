using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class RentalUnit : Entity
    {
        private readonly List<Image> _images = [];

        public IReadOnlyList<Image> Images => _images.AsReadOnly();
        public Address Address { get; private set; }
        public RentalUnitType Type { get; private set; }

        public Guid LandlordId { get; private set; }
        public Landlord? Landlord { get; private set; }

        public RentalUnit(IEnumerable<Image> images, Address address, RentalUnitType type, Guid landlordId)
        {
            ArgumentNullException.ThrowIfNull(images);

            if (!images.Any()) 
                throw new ArgumentException("At least one image is required to create a rental unit.");

            ArgumentNullException.ThrowIfNull(address);

            if (landlordId == Guid.Empty)
                throw new ArgumentException("LandlordId is required to create a rental unit.");

            AddImages(images);
            Address = address;
            Type = type;
            LandlordId = landlordId;
        }

        private void AddImages(IEnumerable<Image> images)
        {
            foreach (var image in images)
            {
                ArgumentNullException.ThrowIfNull(image);
                _images.Add(image);
            }
        }

        private RentalUnit()
        {
            Address = default!;
        }
    }
}
