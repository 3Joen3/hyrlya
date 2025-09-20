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
            if (landlordId == Guid.Empty)
                throw new ArgumentException("LandlordId can't be empty.", nameof(landlordId));

            ArgumentNullException.ThrowIfNull(address);

            if (numberOfRooms < 1)
                throw new ArgumentOutOfRangeException(nameof(numberOfRooms), "NumberOfRooms can't be under 1.");

            if (sizeSquareMeters < 1)
                throw new ArgumentOutOfRangeException(nameof(sizeSquareMeters), "SizeSquareMeters can't be under 1.");

            ArgumentNullException.ThrowIfNull(images);

            if (!images.Any())
                throw new ArgumentException("At least one image is required.", nameof(images));

            LandlordId = landlordId;
            Address = address;
            Type = type;
            NumberOfRooms = numberOfRooms;
            SizeSquareMeters = sizeSquareMeters;
            AddImages(images);
        }

        public void ChangeAddress(Address newAddress)
        {
            ArgumentNullException.ThrowIfNull(newAddress);
            Address = newAddress;
        }

        public void ChangeType(RentalUnitType newType) => Type = newType;

        public void ChangeNumberOfRooms(int newNumberOfRooms)
        {
            if (newNumberOfRooms < 1)
                throw new ArgumentOutOfRangeException(nameof(newNumberOfRooms), "NumberOfRooms can't be under 1.");

            NumberOfRooms = newNumberOfRooms;
        }

        public void ChangeSizeSquareMeters(int newSize)
        {
            if (newSize < 1)
                throw new ArgumentOutOfRangeException(nameof(newSize), "SizeSquareMeters can't be under 1.");

            SizeSquareMeters = newSize;
        }

        public void ReplaceImages(IEnumerable<Image> newImages)
        {
            ArgumentNullException.ThrowIfNull(newImages);

            if (!newImages.Any())
                throw new ArgumentException("At least one image is required.", nameof(newImages));

            _images.Clear();
            AddImages(newImages);
        }

        //NOT TEST
        public bool IsOwnedBy(Guid landlordId) => LandlordId == landlordId;

        private void AddImages(IEnumerable<Image> images)
        {
            foreach (var image in images)
            {
                ArgumentNullException.ThrowIfNull(image);
                _images.Add(image);
            }
        }

        private RentalUnit() { Address = default!; }
    }
}
