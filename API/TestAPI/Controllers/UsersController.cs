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
    public class UsersController : GeneralControllers
    {
        public UsersController(MyTunesContext context) :base(context)
        {
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUSER()
        {
            return await _context.USER
                .Include(a => a.notes)
                    //.ThenInclude(b => b.Musique) Pas besoin
                .Include(c => c.playlists)    
                    //.ThenInclude(d => d.Musique) lourd à la lecture, enelevé pour l'instant
                .ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.USER
                .Include(a => a.notes)
                    //.ThenInclude(b => b.Musique) Pas besoin, déjà là pour playlist
                .Include(c => c.playlists)
                    //.ThenInclude(d => d.Musique) lourd à la lecture, enelevé pour l'instant
                .Where(e => e.id_user == id)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id,[FromBody] User user, 
            [FromHeader] string pseudo, [FromHeader] string passwd, [FromHeader] string token)
        {
            if(!UserAdmin(pseudo, passwd, token))
            {
                return BadRequest(new Erreur("Ce n'est pas un admin"));
            }
            if (id != user.id_user)
            {
                return BadRequest(new Erreur("On ne peut pas modifier un id"));
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            //Faire en sorte que c'est le client ou l'API qui génère le token
            var changement = user;
            changement.playlists = null;
            changement.notes = null;
            _context.USER.Add(changement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = changement.id_user }, changement);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id,
            [FromHeader] string pseudo, [FromHeader] string passwd, [FromHeader] string token)
        {
            if (!UserAdmin(pseudo, passwd, token))
            {
                return BadRequest(new Erreur("Ce n'est pas un admin"));
            }
            var user = await _context.USER.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.USER.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        // POST : api/Users/playlists/1?nom="nom"&publique=bool
        // Ajoute une musique à la playlist nommé si elle n'existe pas la créer, sinon met en favoris par défaut
        [HttpPost("playlist/{id}")]
        public async Task<ActionResult<User>> PostUserPlaylist(int id, 
            [FromBody] IEnumerable<int> musiques, 
            [FromHeader] string nom = "Favoris", [FromHeader] System.Boolean publique = true)
        {
            if (!UserExists(id))
            {
                return NotFound(new Erreur("User numéro: " + id + " inexistant"));
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
                if (!PlaylistExists(id, nom, musique))
                {
                    Playlist playlist = new Playlist()
                    {
                        id_user = id,
                        id_musique = musique,
                        nom = nom,
                        publique = publique
                    };
                    _context.PLAYLIST.Add(playlist);
                }
            }
            await _context.SaveChangesAsync();

            var result = await _context.USER
                .Include(a => a.notes)
                //.ThenInclude(b => b.Musique) Pas besoin, déjà là pour playlist
                .Include(c => c.playlists)
                //.ThenInclude(d => d.Musique) lourd à la lecture, enelevé pour l'instant
                .Where(e => e.id_user == id)
                .FirstOrDefaultAsync();

            return Ok(result);
        }

        // POST : api/Users/notes/1?note=note&musique="id_musique"
        // Ajoute une note à la musique voulu
        [HttpPost("notes/{id}")]
        public async Task<ActionResult<User>> PostUserNotes(int id, 
            [FromHeader] int note, [FromHeader] int musique)
        {
            if (!UserExists(id))
            {
                return NotFound(new Erreur("User numéro: " + id + " inexistant"));
            }
            if (!MusiqueExists(musique))
            {
                return NotFound(new Erreur("Musique numéro: " + musique + " inexistante"));
            }
            if(note > 5 || note < 0)
            {
                return BadRequest(new Erreur("La note doit être compris entre 0 et 5 inclus"));
            }

            Note nt = new Note()
             {
                id_user = id,
                id_musique = musique,
                note = note
             };
             _context.NOTE.Add(nt);
  
            await _context.SaveChangesAsync();

            var result = await _context.USER
                .Include(a => a.notes)
                //.ThenInclude(b => b.Musique) Pas besoin, déjà là pour playlist
                .Include(c => c.playlists)
                //.ThenInclude(d => d.Musique) lourd à la lecture, enelevé pour l'instant
                .Where(e => e.id_user == id)
                .FirstOrDefaultAsync();

            return Ok(result);
        }
    }
}
