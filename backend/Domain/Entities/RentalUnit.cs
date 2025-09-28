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
        public string Description { get; private set; }
        public int NumberOfRooms { get; private set; }
        public int SizeSquareMeters { get; private set; } 

        public Guid LandlordId { get; private set; }
        public Landlord? Landlord { get; private set; }

        public RentalUnit(Guid landlordId, Address address, RentalUnitType type, string description,
            int numberOfRooms, int sizeSquareMeters, IEnumerable<WebAddress> imageUrls)
        {
            LandlordId = SetLandlordId(landlordId);
            Address = SetAddress(address);
            Type = type;
            Description = SetDescription(description);
            NumberOfRooms = SetNumberOfRooms(numberOfRooms);;
            SizeSquareMeters = SetSizeSquareMeters(sizeSquareMeters);
            AddImages(imageUrls);
        }

        public void ChangeAddress(Address newAddress) => Address = SetAddress(newAddress);
        public void ChangeType(RentalUnitType newType) => Type = newType;
        public void ChangeDescription(string description) => Description = SetDescription(description);
        public void ChangeNumberOfRooms(int newNumberOfRooms) => NumberOfRooms = SetNumberOfRooms(newNumberOfRooms);
        public void ChangeSizeSquareMeters(int newSize) => SizeSquareMeters = SetSizeSquareMeters(newSize);
        public bool IsOwnedBy(Guid landlordId) => LandlordId == landlordId;

        public void ReplaceImages(IEnumerable<WebAddress> imageUrls)
        {
            ArgumentNullException.ThrowIfNull(imageUrls);

            if (!imageUrls.Any())
                throw new ArgumentException("At least one image is required.", nameof(imageUrls));

            var images = BuildImages(imageUrls);

            _images.Clear();
            _images.AddRange(images);
        }

        private void AddImages(IEnumerable<WebAddress> imageUrls)
        {
            ArgumentNullException.ThrowIfNull(imageUrls);

            if (!imageUrls.Any())
                throw new ArgumentException("At least one image is required.", nameof(imageUrls));

            var images = BuildImages(imageUrls);
            _images.AddRange(images);
        }

        private static IEnumerable<Image> BuildImages(IEnumerable<WebAddress> imageUrls)
        {
            return [.. imageUrls.Select(url => new Image(url, "Bild från bostadsannons"))];
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

        private static string SetDescription(string description)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(description);
            return description;
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

        private RentalUnit() 
        { 
            Address = default!;
            Description = default!;
        }
    }
}
