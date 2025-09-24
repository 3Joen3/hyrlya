using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Requests
{
    public class ListingRequest
    {
        [Required]
        public Guid RentalUnitId { get; init; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RentalType RentalType { get; init; }

    }
}
