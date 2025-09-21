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
            LandlordId = SetLandlordId(landlordId);
            Address = SetAddress(address);
            Type = type;
            NumberOfRooms = SetNumberOfRooms(numberOfRooms);;
            SizeSquareMeters = SetSizeSquareMeters(sizeSquareMeters);
            AddImages(imageUrls);
        }

        public void ChangeAddress(Address newAddress) => Address = SetAddress(newAddress);
        public void ChangeType(RentalUnitType newType) => Type = newType;
        public void ChangeNumberOfRooms(int newNumberOfRooms) => NumberOfRooms = SetNumberOfRooms(newNumberOfRooms);
        public void ChangeSizeSquareMeters(int newSize) => SizeSquareMeters = SetSizeSquareMeters(newSize);
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

            foreach (var url in imageUrls)
            {
                ArgumentNullException.ThrowIfNull(url);
                var alt = $"Bild från bostadsannons";
                var image = new Image(url, alt);
                _images.Add(image);
            }
        }

        private static Guid SetLandlordId(Guid landlordId)
        {
            if (landlordId == Guid.Empty)
                throw new ArgumentException("LandlordId can't be empty.", nameof(landlordId));

            return landlordId;
        }

        private static Address SetAddress(Address address)
        {
            ArgumentNullException.ThrowIfNull(address);
            return address;
        }

        private static int SetNumberOfRooms(int numberOfRooms)
        {
            if (numberOfRooms < 1)
                throw new ArgumentOutOfRangeException(nameof(numberOfRooms), "NumberOfRooms can't be under 1.");

            return numberOfRooms;
        }

        private static int SetSizeSquareMeters(int sizeSquareMeters)
        {
            if (sizeSquareMeters < 1)
                throw new ArgumentOutOfRangeException(nameof(sizeSquareMeters), "SizeSquareMeters can't be under 1.");

            return sizeSquareMeters;
        }

        private RentalUnit() { Address = default!; }
    }
}
