using Domain.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class LandlordProfile : Entity
    {
        public string Name { get; private set; }
        public Image? Image { get; private set; }
        public PhoneNumber? PhoneNumber { get; private set; }
        public EmailAddress? EmailAddress { get; private set; }

        public Guid LandlordId { get; private set; }
        public Landlord Landlord { get; private set; }

        internal LandlordProfile(string name, Landlord landlord , WebAddress? imageUrl = null,
            PhoneNumber? phoneNumber = null, EmailAddress? emailAddress = null)
        {
            SetName(name);
            SetContactDetails(phoneNumber, emailAddress);
            SetLandlord(landlord);

            if (imageUrl is not null)
                SetImage(imageUrl);
        }

        [MemberNotNull(nameof(Name))]
        public void SetName(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            Name = name;
        }

        public void SetImage(WebAddress imageUrl)
        {
            var altText = $"Hyresvärd {Name} - Profilbild";
            Image = new Image(imageUrl, altText);
        }

        public void SetContactDetails(PhoneNumber? phoneNumber, EmailAddress? emailAddress)
        {
            if (phoneNumber is null && emailAddress is null)
                throw new ArgumentException("At least one method of contact (phone or email) must be provided.");

            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }

        [MemberNotNull(nameof(Landlord))]
        public void SetLandlord(Landlord landlord)
        {
            ArgumentNullException.ThrowIfNull(landlord);

            Landlord = landlord;
            LandlordId = landlord.Id;
        }

        private LandlordProfile() 
        { 
            Name = default!; 
            Landlord = default!;
        }
    }
}
