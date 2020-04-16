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
    public class EditeursController : PatternnControllers
    {
        public EditeursController(MyTunesContext context) :base(context)
        {
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
    }
}
