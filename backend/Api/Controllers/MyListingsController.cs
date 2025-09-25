using Api.Requests;
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
            var dto = request.ToDto();
            var listing = await _myListingService.CreateAsync(IdentityId, dto);
            return Ok(listing);
        }
    }
}
