using Domain.ValueObjects;
using Domain.Enums;

namespace Domain.Entities
{
    public class RentalUnit : Entity
    {
        private readonly List<Image> _images = [];
        public IReadOnlyList<Image> Images => _images.AsReadOnly();

        public Address Address { get; private set; }
        public RentalUnitType Type { get; private set; }
        public int NumberOfRooms { get; private set; }
        public int SizeSquareMeters { get; private set; }

        public Guid LandlordId { get; private set; }
        public Landlord? Landlord { get; private set; }

        public RentalUnit(Guid landlordId, Address address, RentalUnitType type, 
            int numberOfRooms, int sizeSquareMeters, IEnumerable<Image> images)
        {
            Guard.AgainstEmpty(landlordId, nameof(Landlord));
            Guard.AgainstNull(address, nameof(address));
            Guard.AgainstOutOfRange(numberOfRooms, 1, nameof(numberOfRooms));
            Guard.AgainstOutOfRange(sizeSquareMeters, 1, nameof(sizeSquareMeters));
            Guard.AgainstNull(images, nameof(images));
            Guard.AgainstEmptyCollection(images, nameof(images));
             
            LandlordId = landlordId;
            Address = address;
            Type = type;
            NumberOfRooms = numberOfRooms;
            SizeSquareMeters = sizeSquareMeters;
            AddImages(images);
        }

        private void AddImages(IEnumerable<Image> images)
        {
            Guard.AgainstNull(images, nameof(images));

            foreach (var image in images)
            {
                Guard.AgainstNull(image, nameof(image));
                _images.Add(image);
            }
        }

        private RentalUnit() { Address = default!; }
    }
}
