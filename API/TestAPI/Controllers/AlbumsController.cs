using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTunes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTunes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : GeneralControllers
    {
        public AlbumsController(MyTunesContext context) : base(context)
        {
        }

        // GET: api/Albums?recherche="string"
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetALBUM([FromHeader] string recherche)
        {
            var albums = await _context.ALBUM
                .Include(a => a.musiques)
                    .ThenInclude(b => b.Musique)
                .Include(c => c.pochette)
                .ToListAsync();
            if (!string.IsNullOrEmpty(recherche))
            {
                return Ok(albums.Where(s => s.nom_album.ToLower().Contains(recherche.ToLower())));
            }

            return Ok(albums);
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _context.ALBUM
                .Include(a => a.musiques)
                    .ThenInclude(b => b.Musique)
                .Include(c => c.pochette)
                .Where(d => d.id_album == id)
                .FirstOrDefaultAsync();

            if (album == null)
            {
                return NotFound(new Erreur("Album numéro: " + id + " inexistant"));
            }

            return album;
        }

        // POST: api/Albums
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            var changement = album;
            changement.musiques = null;
            _context.ALBUM.Add(changement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbum", new { id = changement.id_album }, changement);
        }

        // POST : api/Albums/pistes/1
        // Ajout une liste de musique à l'album 1
        [HttpPost("pistes/{id}")]
        public async Task<ActionResult<Album>> PostAlbumPistes(int id, [FromBody] IEnumerable<int> musiques)
        {
            if (!AlbumExists(id))
            {
                return NotFound(new Erreur("Album numéro: " + id + " inexistant"));
            }
            foreach (var musique in musiques)
            {
                if (!MusiqueExists(musique))
                {
                    return NotFound(new Erreur("Musique numéro: " + musique + " inexistante"));
                }
            }

            int piste = _context.APPARTIENT_A
                .Where(a => a.id_album == id)
                .Count();

            foreach (var musique in musiques)
            {
                Appartient_a appartient = new Appartient_a()
                {
                    id_album = id,
                    id_musique = musique,
                    num_piste = ++piste
                };
                _context.APPARTIENT_A.Add(appartient);
            }
            await _context.SaveChangesAsync();

            var result = await _context.ALBUM
                .Include(a => a.musiques)
                    .ThenInclude(b => b.Musique)
                .Where(c => c.id_album == id)
                .FirstOrDefaultAsync();

            return Ok(result);
        }

        // PUT : api/Albums/pochette/1
        // Changer la pochette d'un album
        [HttpPut("pochette/{id}")]
        public async Task<ActionResult<Album>> PutAlbumPochette(int id, [FromBody] int pochette)
        {
            if (!AlbumExists(id))
            {
                return BadRequest(new Erreur("Album numéro: " + id + " inexistant"));
            }
            if (!PochetteExists(pochette))
            {
                return NotFound(new Erreur("Pochette numéro: " + pochette + " inexistante"));
            }

            Album alb = await _context.ALBUM
                .Include(a => a.musiques)
                    .ThenInclude(b => b.Musique)
                .Where(c => c.id_album == id)
                .FirstOrDefaultAsync();

            alb.pochette = await _context.POCHETTE.FindAsync(pochette);

            _context.Entry(alb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            var result = await _context.ALBUM
                .Include(a => a.musiques)
                    .ThenInclude(b => b.Musique)
                .Where(c => c.id_album == id)
                .FirstOrDefaultAsync();

            return Ok(result);
        }
    }
}
