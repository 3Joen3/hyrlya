using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Requests
{
    public class ListingRequest
    {
        [Required]
        public Guid RentalUnitId { get; init; }

        [Required, Range(0.01, double.MaxValue)]
        public decimal Price { get; init; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ChargeInterval ChargeInterval { get; init; }

        public string? LandlordNote { get; init; }
    }
}
