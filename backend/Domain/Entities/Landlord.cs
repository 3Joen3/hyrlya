using Domain.Entities.Abstract;

namespace Domain.Entities
{
    public class Landlord : Entity
    {
        public string IdentityId { get; private set; }

        public Landlord(string identityId)
        {
            ArgumentNullException.ThrowIfNull(identityId);

            if (string.IsNullOrWhiteSpace(identityId))
                throw new ArgumentException("IdentityId cannot be empty or whitespace.", nameof(identityId));

            IdentityId = identityId;
        }

        private Landlord()
        {
            IdentityId = default!;
        }
    }
}
