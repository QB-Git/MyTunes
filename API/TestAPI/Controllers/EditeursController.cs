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
    public class EditeursController : ControllerBase
    {
        private readonly MyTunesContext _context;

        public EditeursController(MyTunesContext context)
        {
            _context = context;
        }

        // GET: api/Editeurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editeur>>> GetEDITEUR()
        {
            return await _context.EDITEUR.ToListAsync();
        }

        // GET: api/Editeurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editeur>> GetEditeur(int id)
        {
            var editeur = await _context.EDITEUR.FindAsync(id);

            if (editeur == null)
            {
                return NotFound();
            }

            return editeur;
        }

        // PUT: api/Editeurs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditeur(int id, Editeur editeur)
        {
            if (id != editeur.id_editeur)
            {
                return BadRequest();
            }

            _context.Entry(editeur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditeurExists(id))
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

        // POST: api/Editeurs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Editeur>> PostEditeur(Editeur editeur)
        {
            _context.EDITEUR.Add(editeur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditeur", new { id = editeur.id_editeur }, editeur);
        }

        // DELETE: api/Editeurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Editeur>> DeleteEditeur(int id)
        {
            var editeur = await _context.EDITEUR.FindAsync(id);
            if (editeur == null)
            {
                return NotFound();
            }

            _context.EDITEUR.Remove(editeur);
            await _context.SaveChangesAsync();

            return editeur;
        }

        private bool EditeurExists(int id)
        {
            return _context.EDITEUR.Any(e => e.id_editeur == id);
        }
    }
}
