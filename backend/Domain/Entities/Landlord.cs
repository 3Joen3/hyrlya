using HyrLya.Domain.Entities.Abstract;

namespace HyrLya.Domain.Entities
{
    public class Landlord : Entity
    {
        public string IdentityId { get; private set; }

        public Landlord(string identityId)
        {
            if (string.IsNullOrWhiteSpace(identityId))
                throw new ArgumentNullException(nameof(identityId));

            IdentityId = identityId;
        }

        private Landlord() 
        {
            IdentityId = default!;
        }
    }
}
