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
    }
}
    