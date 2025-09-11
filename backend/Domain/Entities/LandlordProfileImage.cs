using Domain.Entities.Abstract;

namespace Domain.Entities
{
    public class LandlordProfileImage : Image
    {
        public Guid LandlordProfileId { get; private set; }
        public LandlordProfile? LandlordProfile { get; private set; }

        public LandlordProfileImage(string url, string? altText = null)
            : base(url, altText) { }

        private LandlordProfileImage() { LandlordProfile = default!; }
    }
}
