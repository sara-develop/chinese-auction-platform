using Microsoft.AspNetCore.Mvc;
using WebAPI_project.DTOs;

namespace WebAPI_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorsController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DonorGetDto>>> GetAll()
        {
            var donors = await _donorService.GetAllAsync();
            return Ok(donors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DonorGetDto>> Get(int id)
        {
            var donor = await _donorService.GetByIdAsync(id);
            if (donor == null) return NotFound();
            return Ok(donor);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] DonorCreateDto dto)
        {
            var id = await _donorService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] DonorUpdateDto dto)
        {
            var success = await _donorService.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _donorService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
