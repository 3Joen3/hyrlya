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
        public int NumberOfRooms { get; private set; }
        public int SizeSquareMeters { get; private set; }

        public Guid LandlordId { get; private set; }
        public Landlord? Landlord { get; private set; }

        public RentalUnit(Guid landlordId, Address address, RentalUnitType type, 
            int numberOfRooms, int sizeSquareMeters, IEnumerable<WebAddress> imageUrls)
        {
            if (landlordId == Guid.Empty)
                throw new ArgumentException("LandlordId can't be empty.", nameof(landlordId));

            ArgumentNullException.ThrowIfNull(address);

            if (numberOfRooms < 1)
                throw new ArgumentOutOfRangeException(nameof(numberOfRooms), "NumberOfRooms can't be under 1.");

            if (sizeSquareMeters < 1)
                throw new ArgumentOutOfRangeException(nameof(sizeSquareMeters), "SizeSquareMeters can't be under 1.");

            LandlordId = landlordId;
            Address = address;
            Type = type;
            NumberOfRooms = numberOfRooms;
            SizeSquareMeters = sizeSquareMeters;
            AddImages(imageUrls);
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

        public bool IsOwnedBy(Guid landlordId) => LandlordId == landlordId;

        public void ReplaceImages(IEnumerable<WebAddress> imageUrls)
        {
            _images.Clear();
            AddImages(imageUrls);
        }

        private void AddImages(IEnumerable<WebAddress> imageUrls)
        {
            ArgumentNullException.ThrowIfNull(imageUrls);

            if (!imageUrls.Any())
                throw new ArgumentException("At least one image is required.", nameof(imageUrls));

            foreach(var url in imageUrls)
            {
                ArgumentNullException.ThrowIfNull(url);
                var alt = $"Bild från bostadsannons";
                var image = new Image(url, alt);
                _images.Add(image);
            }
        }

        private RentalUnit() { Address = default!; }
    }
}
