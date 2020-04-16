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
    public class ArtistesController : PatternnControllers
    {
        public ArtistesController(MyTunesContext context) : base(context)
        {
        }

        // GET: api/Artistes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artiste>>> GetARTISTE()
        {
            return await _context.ARTISTE.ToListAsync();
        }

        // GET: api/Artistes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artiste>> GetArtiste(int id)
        {
            var artiste = await _context.ARTISTE.FindAsync(id);

            if (artiste == null)
            {
                return NotFound();
            }

            return artiste;
        }

        // POST: api/Artistes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Artiste>> PostArtiste(Artiste artiste)
        {
            _context.ARTISTE.Add(artiste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtiste", new { id = artiste.id_artiste }, artiste);
        }
    }
}
