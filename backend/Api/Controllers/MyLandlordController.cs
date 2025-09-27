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

        [HttpGet]
        public async Task<IActionResult> GetMyLandlord()
        {
            var landlord = await _myLandlordService
                .GetWithProfileByIdentityIdAsync(IdentityId);

            if (landlord is null)
                return NotFound();

            var response = new LandlordDetails(landlord);

            return Ok(response);
        }
    }
}
