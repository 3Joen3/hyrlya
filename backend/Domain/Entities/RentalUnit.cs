using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class RentalUnit : Entity
    {
        private readonly List<Image> _images = [];

        public Address Address { get; private set; }
        public RentalUnitType Type { get; private set; }
        public int Rooms { get; private set; }
        public int SizeSquareMeters { get; private set; }
        public IReadOnlyList<Image> Images => _images.AsReadOnly();

        public Guid LandlordId { get; private set; }
        public Landlord? Landlord { get; private set; }

        public RentalUnit(Guid landlordId, Address address, RentalUnitType type, 
            int rooms, int sizeSquareMeters, IEnumerable<Image> images)
        {
            Address = default!;

            SetLandlordId(landlordId);
            SetAddress(address);
            Type = type;
            SetRooms(rooms);
            SetSizeSquareMeters(sizeSquareMeters);
            SetImages(images);
        }

        private RentalUnit() { Address = default!; }

        private void SetLandlordId(Guid landlordId)
        {
            if (landlordId == Guid.Empty) 
                throw new ArgumentException("LandlordId is required to create a rental unit.");
            
            LandlordId = landlordId;
        }

        private void SetAddress(Address address)
        {
            ArgumentNullException.ThrowIfNull(address);
            Address = address;
        }

        private void SetRooms(int rooms)
        {
            if (rooms < 1) 
                throw new ArgumentException("Rooms can't be zero when creating a rental unit.");

            Rooms = rooms;
        }

        private void SetSizeSquareMeters(int sizeSquareMeters)
        {
            if (sizeSquareMeters < 1) 
                throw new ArgumentException("Size can't be zero when creating a rental unit.");
            
            SizeSquareMeters = sizeSquareMeters;
        }

        private void SetImages(IEnumerable<Image> images)
        {
            ArgumentNullException.ThrowIfNull(images);

            if (!images.Any())
                throw new ArgumentException("At least one image is required to create a rental unit.");

            _images.Clear();
            AddImages(images);
        }

        private void AddImages(IEnumerable<Image> images)
        {
            foreach (var image in images)
            {
                ArgumentNullException.ThrowIfNull(image);
                _images.Add(image);
            }
        }
    }
}
