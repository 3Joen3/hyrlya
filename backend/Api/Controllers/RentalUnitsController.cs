using Api.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentalUnitsController(IRentalUnitService rentalUnitService) : ControllerBase
    {
        private readonly IRentalUnitService _rentalUnitService = rentalUnitService;

        private string? IdentityId 
            => User.FindFirstValue(ClaimTypes.NameIdentifier);

        [HttpPost]
        public async Task<IActionResult> CreateMyRentalUnit([FromBody] RentalUnitRequest request)
        {
            if (string.IsNullOrEmpty(IdentityId))
                return Unauthorized();

            var rentalUnit = await _rentalUnitService.CreateAsync(IdentityId, request.Street, request.HouseNumber, request.City,
                request.Type, request.Rooms, request.SizeSquareMeters, request.ImageUrls );

            return Ok(rentalUnit);
        }
    }
}
