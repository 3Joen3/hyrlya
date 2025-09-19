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

        public void ChangeAddress(Address newAddress)
        {
            Guard.AgainstNull(newAddress, nameof(newAddress));
            Address = newAddress;
        }

        public void ChangeType(RentalUnitType newType) => Type = newType;

        public void ChangeNumberOfRooms(int newNumberOfRooms)
        {
            Guard.AgainstOutOfRange(newNumberOfRooms, 1, nameof(newNumberOfRooms));
            NumberOfRooms = newNumberOfRooms;
        }

        public void ChangeSizeSquareMeters(int newSize)
        {
            Guard.AgainstOutOfRange(newSize, 1, nameof(newSize));
            SizeSquareMeters = newSize;
        }

        public void ReplaceImages(IEnumerable<Image> newImages)
        {
            Guard.AgainstNull(newImages, nameof(newImages));
            Guard.AgainstEmptyCollection(newImages, nameof(newImages));

            _images.Clear();
            AddImages(newImages);
        }

        //NOT TEST
        public bool IsOwnedBy(Guid landlordId) 
            => LandlordId == landlordId;

        private void AddImages(IEnumerable<Image> images)
        {
            foreach (var image in images)
            {
                Guard.AgainstNull(image, nameof(image));
                _images.Add(image);
            }
        }

        private RentalUnit() { Address = default!; }
    }
}
