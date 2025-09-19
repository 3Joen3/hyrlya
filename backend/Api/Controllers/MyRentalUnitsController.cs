using Api.Requests;
using Api.Responses;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Route("my/rental-units")]
    [Authorize]
    public class MyRentalUnitsController(IMyRentalUnitService myRentalUnitService) : ControllerBase
    {
        private readonly IMyRentalUnitService _myRentalUnitService = myRentalUnitService;

        public string IdentityId => User
            .FindFirstValue(ClaimTypes.NameIdentifier)!;

        [HttpPost]
        public async Task<IActionResult> CreateMyRentalUnit([FromBody] RentalUnitRequest request)
        {
            var dto = request.ToDto();
            var rentalUnit = await _myRentalUnitService.CreateAsync(IdentityId, dto);

            return Ok(rentalUnit);
        }

        [HttpGet]
        public async Task<IActionResult> GetMyRentalUnits()
        {
            var rentalUnits = await _myRentalUnitService
                .GetAllAsync(IdentityId);

            var response = rentalUnits
                .Select(rentalUnit => new RentalUnitSummary(rentalUnit));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMyRentalUnitById(Guid id)
        {
            var rentalUnit = await _myRentalUnitService
                .GetByIdAsync(IdentityId, id);

            if (rentalUnit == null)
                return NotFound();

            var response = new RentalUnitDetails(rentalUnit);

            return Ok(response);
        }
    }
}
