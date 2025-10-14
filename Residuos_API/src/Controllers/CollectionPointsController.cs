using Microsoft.AspNetCore.Mvc;
using RecyclingManagementAPI.Models;
using RecyclingManagementAPI.Services;

namespace RecyclingManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionPointsController : ControllerBase
    {
        private readonly CollectionPointService _service;

        public CollectionPointsController(CollectionPointService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _service.GetAllAsync(page, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCollectionPointViewModel model)
        {
            var createdPoint = await _service.CreateAsync(model);
            return CreatedAtAction(nameof(GetAll), new { id = createdPoint.Id }, createdPoint);
        }

        [HttpPut("{id}/waste")]
        public async Task<IActionResult> UpdateWasteAmount(int id, [FromBody] int newAmount)
        {
            var updated = await _service.UpdateWasteAmountAsync(id, newAmount);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpGet("alerts")]
        public async Task<IActionResult> GetFullCapacityAlerts()
        {
            var fullPoints = await _service.GetFullCapacityPointsAsync();
            return Ok(fullPoints);
        }
    }
}