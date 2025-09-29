using Api.Responses.Landlords;
using Api.Responses.RentalUnits;
using Domain.Entities;

namespace Api.Responses.Listings
{
    public class ListingDetails(Listing listing)
    { 
        public LandlordProfileDetails Landlord { get; } = listing.Landlord is null ? throw new ArgumentException("Landlord must be loaded") :  new LandlordProfileDetails(listing.Landlord.Profile);
        public RentalUnitDetails RentalUnit { get; } = listing.RentalUnit is null ? throw new ArgumentException("RentalUnit must be loaded") : new RentalUnitDetails(listing.RentalUnit);
        public RentalPriceResponse RentalPrice { get; } = new RentalPriceResponse(listing.RentalPrice);
        public string? LandlordNote { get; } = listing.LandlordNote;
    }
}
