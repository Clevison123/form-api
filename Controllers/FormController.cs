using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormAPI.Data;
using FormAPI.Models;

namespace FormApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private readonly AppDbContext _context; // <-- isso injeta o banco no controller

        public FormController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetForms()
        {
            var forms = await _context.Forms.ToListAsync();
            return Ok(forms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormById(int id)
        {
            var form = await _context.Forms.FindAsync(id);
            if (form == null) return NotFound();
            return Ok(form);
        }

        [HttpPost]
        public async Task<IActionResult> AddForm([FromBody] PersonForm form)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _context.Forms.AddAsync(form);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFormById), new { id = form.Id }, form);
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteForm(int id)
        {
            var form = await _context.Forms.FindAsync(id);
            if (form == null) return NotFound();

            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok("API is running...");
        }
    }
}
