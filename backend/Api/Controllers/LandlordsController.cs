using Api.Requests;
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

            var landlord = await _landlordService.GetByIdentityIdAsync(IdentityId);

            if (landlord is null)
                return NotFound();

            var response = new LandlordResponse(landlord);

            return landlord is null 
                ? NotFound() 
                : Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLandlord([FromBody] LandlordRequest request)
        {
            if (string.IsNullOrEmpty(IdentityId))
                return Unauthorized();

            var landlord = await _landlordService.CreateAsync(IdentityId, request.Name, request.ProfileImageUrl,
                request.Contact.PhoneNumber, request.Contact.EmailAddress);

            var response = new LandlordResponse(landlord);

            return Ok(response);
        }
    }
}
