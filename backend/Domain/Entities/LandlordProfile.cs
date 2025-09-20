using Domain.ValueObjects;

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
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentNullException.ThrowIfNull(landlord);

            if (phoneNumber is null && emailAddress is null) 
                throw new ArgumentException("At least one method of contact (phone or email) must be provided.");

            Image? image = null;

            if (imageUrl is not null)
                image = BuildProfileImage(imageUrl);

            Name = name;
            Image = image;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            LandlordId = landlord.Id;
            Landlord = landlord;
        }
         
        private Image BuildProfileImage(WebAddress imageUrl)
        {
            var altText = $"Hyresvärd {Name} - Profilbild";
            return new Image(imageUrl, altText);
        }

        private LandlordProfile() 
        { 
            Name = default!; 
            Landlord = default!;
        }
    }
}
