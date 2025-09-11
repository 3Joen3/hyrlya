using Domain.Entities.Abstract;

namespace Domain.Entities
{
    public class LandlordProfile : Entity
    {
        public LandlordProfileImage? Image { get; private set; }

        public LandlordProfile(LandlordProfileImage? profileImage = null)
        {
            Image = profileImage;
        }

        private LandlordProfile() { }
    }
}
