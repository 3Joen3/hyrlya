using System.ComponentModel.DataAnnotations;

namespace Api.Requests
{
    public class AddressRequest
    {
        [Required, MinLength(1)]
        public string Street { get; init; } = default!;

        [Required, MinLength(1)]
        public string HouseNumber { get; init; } = default!;

        [Required, MinLength(1)]
        public string City { get; init; } = default!;
    }
}
