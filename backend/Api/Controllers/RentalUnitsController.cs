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

            var rentalUnit = await _rentalUnitService.CreateAsync(IdentityId, request.Street, request.HouseNumber,
                request.City, request.Type, request.Rooms, request.SizeSquareMeters, request.ImageUrls );

            return Ok(rentalUnit);
        }

        [HttpGet]
        public async Task<IActionResult> GetMyRentalUnits()
        {
            if (string.IsNullOrEmpty(IdentityId))
                return Unauthorized();

            var rentalUnits = await _rentalUnitService.GetAllByIdentityIdAsync(IdentityId);

            var responseModels = rentalUnits
                .Select(rentalUnit => new RentalUnitSummary(rentalUnit));

            return Ok(responseModels);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMyRentalUnitById(Guid id)
        {
            if (string.IsNullOrEmpty(IdentityId))
                return Unauthorized();

            var rentalUnit = await _rentalUnitService.GetByIdAsync(id);

            if (rentalUnit == null)
                return NotFound();

            var response = new RentalUnitDetails(rentalUnit);

            return Ok(response);
        }
    }
}
