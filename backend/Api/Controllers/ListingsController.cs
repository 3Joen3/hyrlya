using Api.Responses.Listings;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListingsController(IListingService listingService) : ControllerBase
    {
        private readonly IListingService _listingsService = listingService;

        [HttpGet]
        public async Task<IActionResult> GetPaginated([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _listingsService.GetFullPaginatedAsync(page, pageSize);

            var response = result
                .Select(listing => new ListingSummary(listing));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetListingDetailsById(Guid id)
        {
            var listing = await _listingsService.GetFullByIdAsync(id);

            if (listing is null)
                return NotFound();

            var response = new ListingDetails(listing);

            return Ok(response);
        }
    }
}
    