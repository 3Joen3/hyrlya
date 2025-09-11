using Domain.Entities.Abstract;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class LandlordProfile : Entity
    {
        public string Name { get; private set; }
        public Image? Image { get; private set; }
        public PhoneNumber? ContactPhone { get; private set; }
        public EmailAddress? ContactEmail { get; private set; }

        public Guid LandlordId { get; private set; }
        public Landlord Landlord { get; private set; }

        internal LandlordProfile(string name, Landlord landlord , Image? image = null,
            PhoneNumber? contactPhone = null, EmailAddress? contactEmail = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            if (contactPhone is null && contactEmail is null) 
                throw new ArgumentException("At least one method of contact (phone or email) must be provided.");

            Name = name;
            Image = image;
            ContactPhone = contactPhone;
            ContactEmail = contactEmail;
            LandlordId = landlord.Id;
            Landlord = landlord;
        }

        private LandlordProfile() { Name = default!; Landlord = default!; }
    }
}
