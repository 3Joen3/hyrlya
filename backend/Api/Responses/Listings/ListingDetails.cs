using Api.Responses.Landlords;
using Api.Responses.RentalUnits;
using Domain.Entities;

namespace Api.Responses.Listings
{
    public class ListingDetails
    { 
        public LandlordProfileDetails LandlordProfile { get; }
        public RentalUnitDetails RentalUnit { get; }
        public RentalPriceResponse RentalPrice { get; }
        public string? LandlordNote { get; }

        public ListingDetails(Listing listing)
        {
            if (listing.Landlord is null)
                throw new ArgumentException("Landlord must be loaded");

            if (listing.RentalUnit is null)
                throw new ArgumentException("RentalUnit must be loaded");

            LandlordProfile = new LandlordProfileDetails(listing.Landlord.Profile);
            RentalUnit = new RentalUnitDetails(listing.RentalUnit);
            RentalPrice = new RentalPriceResponse(listing.RentalPrice);
            LandlordNote = listing.LandlordNote;
        }
    }
}
