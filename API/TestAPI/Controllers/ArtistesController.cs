using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using MyTunes.Models;

namespace MyTunes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistesController : GeneralControllers
    {
        public ArtistesController(MyTunesContext context) : base(context)
        {
        }

        // GET: api/Artistes?recherche="string"
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artiste>>> GetARTISTE([FromHeader] string recherche)
        {
            var artistes =  await _context.ARTISTE
                .Include(a => a.musiques)
                    .ThenInclude(b => b.Musique)
                .ToListAsync();
            if (!string.IsNullOrEmpty(recherche))
            {
                return Ok(artistes.Where(s => s.nom.ToLower().Contains(recherche.ToLower()) || s.prenom.ToLower().Contains(recherche.ToLower())));
            }

            return Ok(artistes);
        }

        // GET: api/Artistes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artiste>> GetArtiste(int id)
        {
            var artiste = await _context.ARTISTE
                .Include(a => a.musiques)
                    .ThenInclude(b => b.Musique)
                .Where(c => c.id_artiste == id)
                .FirstOrDefaultAsync();

            if (artiste == null)
            {
                return NotFound(new Erreur("Artiste numéro: " + id + " inexistant"));
            }

            return artiste;
        }

        // POST: api/Artistes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Artiste>> PostArtiste(Artiste artiste)
        {
            var changement = artiste;
            changement.musiques = null;
            _context.ARTISTE.Add(changement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtiste", new { id = changement.id_artiste }, changement);
        }

        // POST : api/Artistes/a_fait/1
        // Ajout une liste de musique à l'artiste 1
        [HttpPost("a_fait/{id}")]
        public async Task<ActionResult<Artiste>> PostArtisteA_Fait(int id, [FromBody] IEnumerable<int> musiques)
        {
            if (!ArtisteExists(id))
            {
                return NotFound(new Erreur("Artiste numéro: " + id + " inexistant"));
            }
            foreach (var musique in musiques)
            {
                if (!MusiqueExists(musique))
                {
                    return NotFound(new Erreur("Musique numéro: " + musique + " inexistante"));
                }
            }

            foreach (var musique in musiques)
            {
                A_fait fait = new A_fait()
                {
                    id_artiste = id,
                    id_musique = musique,
                };
                _context.A_FAIT.Add(fait);
            }
            await _context.SaveChangesAsync();

            var result = await _context.ARTISTE
                .Include(a => a.musiques)
                    .ThenInclude(b => b.Musique)
                .Where(c => c.id_artiste == id)
                .FirstOrDefaultAsync();

            return Ok(result);
        }
    }
}
