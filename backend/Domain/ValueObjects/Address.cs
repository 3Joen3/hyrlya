namespace Domain.ValueObjects
{
    public record Address
    {
        public string Street { get; }
        public string HouseNumber { get; }
        public string City { get; }

        public Address(string street, string houseNumber, string city)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(street);
            ArgumentException.ThrowIfNullOrWhiteSpace(houseNumber);
            ArgumentException.ThrowIfNullOrWhiteSpace(city);

            Street = street;
            HouseNumber = houseNumber;
            City = city;
        }
    }
}
