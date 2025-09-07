using HyrLya.Domain.Entities.Abstract;

namespace HyrLya.Domain.Entities
{
    public class Landlord : Entity
    {
        public string UserId { get; private set; }

        public Landlord(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException(nameof(userId));

            UserId = userId;
        }

        private Landlord() 
        {
            UserId = default!;
        }
    }
}
