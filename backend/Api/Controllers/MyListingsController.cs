using Api.Requests;
using Api.Responses.Listings;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Route("my/listings")]
    [Authorize]
    public class MyListingsController(IMyListingService myListingService) : ControllerBase
    {
        private readonly IMyListingService _myListingService = myListingService;

        public string IdentityId => User
            .FindFirstValue(ClaimTypes.NameIdentifier)!;

        [HttpPost]
        public async Task<IActionResult> CreateMyListing([FromBody] ListingRequest request)
        {
            try
            {
                var dto = request.ToDto();
                var listing = await _myListingService.CreateAsync(IdentityId, dto);
                return Ok(listing);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMyListings()
        {
            try
            {
                var listings = await _myListingService
                    .GetAllWithDetailsAsync(IdentityId);

                var response = listings
                    .Select(listing => new ListingSummary(listing));

                return Ok(response);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
