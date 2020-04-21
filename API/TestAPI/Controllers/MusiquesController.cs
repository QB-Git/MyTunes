using System;
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
    public class MusiquesController : GeneralControllers
    {
        public MusiquesController(MyTunesContext context) :base(context)
        {
        }

        // GET: api/Musiques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musique>>> GetMUSIQUE()
        {
            return await _context.MUSIQUE
                .Include(a => a.pochette)
                .Include(b => b.editeur)
                .Include(c => c.artistes)
                    .ThenInclude(d => d.Artiste)
                .Include(e => e.genres)
                    .ThenInclude(f => f.Genre)
                .Include(g => g.albums)
                    .ThenInclude(h => h.Album)
                .Include(i => i.notes)
                    //.ThenInclude(j => j.User) Pas de besoin de connaitre plus d'informations
                /*.Include(k => k.playlists)    Pas Besoin de connaitre les playlists dans lesquelles sont les musiques
                    .ThenInclude(l => l.User)*/
                .ToListAsync();
        }

        // GET: api/Musiques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musique>> GetMusique(int id)
        {
            var musique = await _context.MUSIQUE
                .Include(a => a.pochette)
                .Include(b => b.editeur)
                .Include(c => c.artistes)
                    .ThenInclude(d => d.Artiste)
                .Include(e => e.genres)
                    .ThenInclude(f => f.Genre)
                .Include(g => g.albums)
                    .ThenInclude(h => h.Album)
                .Include(i => i.notes)
                //.ThenInclude(j => j.User) Pas de besoin de connaitre plus d'informations
                /*.Include(k => k.playlists)    Pas Besoin de connaitre les playlists dans lesquelles sont les musiques
                    .ThenInclude(l => l.User)*/
                .Where(m => m.id_musique == id)
                .FirstOrDefaultAsync();

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
    }
}
