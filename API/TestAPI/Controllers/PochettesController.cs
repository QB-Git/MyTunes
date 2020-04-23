using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTunes.Models;

namespace MyTunes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PochettesController : GeneralControllers
    {
        public PochettesController(MyTunesContext context) :base(context)
        {
        }

        // GET: api/Pochettes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pochette>>> GetPOCHETTE()
        {
            return Ok(await _context.POCHETTE.ToListAsync());
        }

        // GET: api/Pochettes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pochette>> GetPochette(int id)
        {
            var pochette = await _context.POCHETTE.FindAsync(id);

            if (pochette == null)
            {
                return NotFound();
            }

            return pochette;
        }

        // PUT: api/Pochettes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPochette(int id, Pochette pochette)
        {
            if (id != pochette.id_pochette)
            {
                return BadRequest();
            }

            _context.Entry(pochette).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PochetteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pochettes
        [HttpPost]
        public async Task<ActionResult<Pochette>> PostPochette(Pochette pochette)
        {
            _context.POCHETTE.Add(pochette);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPochette", new { id = pochette.id_pochette }, pochette);
        }
    }
}
