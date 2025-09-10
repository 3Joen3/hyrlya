using Domain.Entities.Abstract;

namespace Domain.Entities
{
    public class Landlord : Entity
    {
        public string IdentityId { get; private set; }

        public Landlord(string identityId)
        {
            ArgumentNullException.ThrowIfNull(identityId);

            ArgumentException.ThrowIfNullOrWhiteSpace(identityId);

            IdentityId = identityId;
        }

        private Landlord()
        {
            IdentityId = default!;
        }
    }
}
