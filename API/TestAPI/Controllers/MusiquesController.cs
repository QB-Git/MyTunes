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
    public class MusiquesController : ControllerBase
    {
        private readonly MyTunesContext _context;

        public MusiquesController(MyTunesContext context)
        {
            _context = context;
        }

        // GET: api/Musiques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musique>>> GetMUSIQUE()
        {
            return await _context.MUSIQUE.ToListAsync();
        }

        // GET: api/Musiques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musique>> GetMusique(int id)
        {
            var musique = await _context.MUSIQUE.FindAsync(id);

            if (musique == null)
            {
                return NotFound();
            }

            return musique;
        }

        // PUT: api/Musiques/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusique(int id, Musique musique)
        {
            if (id != musique.id_musique)
            {
                return BadRequest();
            }

            _context.Entry(musique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusiqueExists(id))
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

        // POST: api/Musiques
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Musique>> PostMusique(Musique musique)
        {
            _context.MUSIQUE.Add(musique);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusique", new { id = musique.id_musique }, musique);
        }

        // DELETE: api/Musiques/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Musique>> DeleteMusique(int id)
        {
            var musique = await _context.MUSIQUE.FindAsync(id);
            if (musique == null)
            {
                return NotFound();
            }

            _context.MUSIQUE.Remove(musique);
            await _context.SaveChangesAsync();

            return musique;
        }

        private bool MusiqueExists(int id)
        {
            return _context.MUSIQUE.Any(e => e.id_musique == id);
        }
    }
}
