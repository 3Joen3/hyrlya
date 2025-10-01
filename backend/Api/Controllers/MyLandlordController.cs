using Api.Requests;
using Api.Responses.Landlords;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Route("my/landlord")]
    [Authorize]
    public class MyLandlordController(IMyLandlordService myLandlordService) : ControllerBase
    {
        private readonly IMyLandlordService _myLandlordService = myLandlordService;

        public string IdentityId => User
            .FindFirstValue(ClaimTypes.NameIdentifier)!;

        [HttpPost]
        public async Task<IActionResult> CreateMyLandlord([FromBody] LandlordRequest request)
        {
            var dto = request.ToDto();
            var landlord = await _myLandlordService.CreateAsync(IdentityId, dto);

            return Ok(landlord);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMyLandlordProfile([FromBody] LandlordRequest request)
        {
            var dto = request.ToDto();
            var profile = await _myLandlordService.UpdateProfileAsync(IdentityId, dto);
            return Ok(profile);
        }

        [HttpGet]
        public async Task<IActionResult> GetMyLandlordProfile()
        {
            var profile = await _myLandlordService
                .GetProfileAsync(IdentityId);

            if (profile is null)
                return NotFound();

            var response = new LandlordProfileDetails(profile);

            return Ok(response);
        }
    }
}
