using Microsoft.AspNetCore.Mvc;
using WebAPI_project.Models;
using WebAPI_project.DTOs;
using WebAPI_project.Services;


namespace WebAPI_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrizesController : ControllerBase
    {
        private readonly IPrizeService _prizeService;

        public PrizesController(IPrizeService prizeService)
        {
            _prizeService = prizeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrizeGetDto>>> GetAll()
        {
            var prizes = await _prizeService.GetAllAsync();
            return Ok(prizes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrizeGetDto>> Get(int id)
        {
            var prize = await _prizeService.GetByIdAsync(id);
            if (prize == null) return NotFound();
            return Ok(prize);
        }

        [HttpGet("{id}/purchases")]
        public async Task<ActionResult<PrizeGetPurchasersDto>> GetWithPurchases(int id)
        {
            var prize = await _prizeService.GetWithPurchasesAsync(id);
            if (prize == null) return NotFound();
            return Ok(prize);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PrizeCreateDto dto)
        {
            var id = await _prizeService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PrizeUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");
            var success = await _prizeService.UpdateAsync(dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _prizeService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
