using Api.Responses;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class LandlordsController(ILandlordService landlordService) : ControllerBase
    {
        private readonly ILandlordService _landlordService = landlordService;

        private string? IdentityId 
            => User.FindFirstValue(ClaimTypes.NameIdentifier);

        [HttpGet]
        public async Task<IActionResult> GetMyLandlord()
        {
            if (string.IsNullOrEmpty(IdentityId))
                return Unauthorized();

            var landlord = await _landlordService.GetByIdentityId(IdentityId);

            if (landlord is null)
                return NotFound();

            var response = new LandlordResponse(landlord);

            return landlord is null 
                ? NotFound() 
                : Ok(response);
        }
    }
}
