using Domain.Enums;
using Domain.ValueObjects;
using System.Diagnostics.CodeAnalysis;

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
            SetLandlordId(landlordId);
            SetAddress(address);
            SetType(type);
            SetDescription(description);
            SetNumberOfRooms(numberOfRooms);
            SetSizeSquareMeters(sizeSquareMeters);
            AddImages(imageUrls);
        }

        private void SetLandlordId(Guid landlordId)
        {
            if (landlordId == Guid.Empty)
                throw new ArgumentException("LandlordId can't be empty.", nameof(landlordId));

            LandlordId = landlordId;
        }

        public void SetType(RentalUnitType type) => Type = type; 

        [MemberNotNull(nameof(Address))]
        public void SetAddress(Address address)
        {
            ArgumentNullException.ThrowIfNull(address);
            Address = address;
        }

        [MemberNotNull(nameof(Description))]
        public void SetDescription(string description)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(description);
            Description = description;
        }

        public void SetNumberOfRooms(int numberOfRooms)
        {
            if (numberOfRooms < 1)
                throw new ArgumentOutOfRangeException(nameof(numberOfRooms), "NumberOfRooms can't be under 1.");

            NumberOfRooms = numberOfRooms;
        }

        public void SetSizeSquareMeters(int sizeSquareMeters)
        {
            if (sizeSquareMeters < 1)
                throw new ArgumentOutOfRangeException(nameof(sizeSquareMeters), "SizeSquareMeters can't be under 1.");

            SizeSquareMeters = sizeSquareMeters;
        }

        public void SetImages(IEnumerable<WebAddress> imageUrls)
        {
            ArgumentNullException.ThrowIfNull(imageUrls);

            if (!imageUrls.Any())
                throw new ArgumentException("At least one image is required.", nameof(imageUrls));

            var images = BuildImages(imageUrls);

            _images.Clear();
            _images.AddRange(images);
        }

        public bool IsOwnedBy(Guid landlordId) => LandlordId == landlordId;

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

        private RentalUnit() 
        { 
            Address = default!;
            Description = default!;
        }
    }
}
