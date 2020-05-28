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

        // GET: api/Users?recherche="string"
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUSER()
        {
            var users = await _context.USER
                .Include(a => a.notes)
                    //.ThenInclude(b => b.Musique) Pas besoin
                .Include(c => c.playlists)    
                    //.ThenInclude(d => d.Musique) lourd à la lecture, enelevé pour l'instant
                .ToListAsync();

            
                //return Ok(users.Where(s => s.pseudo.ToLower().Contains(recherche.ToLower())));


            return Ok(users);
        }
        
        [HttpGet("recherche/{recherche}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUSERRecherche(string recherche)
        {
            var users = await _context.USER
                .Include(a => a.notes)
                //.ThenInclude(b => b.Musique) Pas besoin
                .Include(c => c.playlists)
                //.ThenInclude(d => d.Musique) lourd à la lecture, enelevé pour l'instant
                .Where(s => s.pseudo.ToLower().Contains(recherche.ToLower()))
                .ToListAsync();

            return Ok(users);
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
            string nom = "Favoris", System.Boolean publique = false)
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

        // POST : api/Users/playlists/1?nom="nom"&publique=bool
        // Ajoute une musique à la playlist nommé si elle n'existe pas la créer, sinon met en favoris par défaut
        [HttpPost("playlist/unique/{id}")]
        public async Task<ActionResult<User>> PostUserPlaylistUn(int id,
            int id_musique,
            string nom = "Favoris", System.Boolean publique = false)
        {
            if (!UserExists(id))
            {
                return NotFound(new Erreur("User numéro: " + id + " inexistant"));
            }
            if (!MusiqueExists(id_musique))
            {
                return NotFound(new Erreur("Musique numéro: " + id_musique + " inexistante"));
            }
                if (!PlaylistExists(id, nom, id_musique))
                {
                    Playlist playlist = new Playlist()
                    {
                        id_user = id,
                        id_musique = id_musique,
                        nom = nom,
                        publique = publique
                    };
                    _context.PLAYLIST.Add(playlist);
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
            int note, int musique)
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

        // PUT: api/Users/playlist/5?musique=id&nom="nom_playlist"
        [HttpPut("playlist/{id}")]
        public async Task<ActionResult<User>> PutUserPlaylist(int id,
            int musique, string nom_playlist)
        {
            if (!UserExists(id))
            {
                return NotFound(new Erreur("User numéro : "+id+" introuvable"));
            }

            var playlist = await _context.PLAYLIST
                .Where(a => a.id_musique == musique && a.id_user==id && a.nom == nom_playlist)
                .FirstOrDefaultAsync();
            if (playlist == null)
            {
                return NotFound(new Erreur("musique numéro : " + musique 
                    + " dans la playlist nommé : "
                    +nom_playlist+" de l'utilisateur numéro: "
                    +id+", introuvable"));
            }

            _context.PLAYLIST.Remove(playlist);
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

        // DELETE: api/Users/playlist/5?nom="nom_playlist"
        [HttpDelete("playlist/{id}")]
        public async Task<ActionResult<User>> DeleteUserPlaylist(int id, string nom_playlist)
        {
            if (!UserExists(id))
            {
                return NotFound(new Erreur("User numéro : " + id + " introuvable"));
            }

            var playlists = await _context.PLAYLIST
                .Where(a => a.id_user == id && a.nom == nom_playlist)
                .ToListAsync();
            if (playlists == null)
            {
                return NotFound(new Erreur("Playlist nommé : "
                    + nom_playlist + " de l'utilisateur numéro: "
                    + id + ", introuvable"));
            }

            foreach(var playlist in playlists)
            {
                _context.PLAYLIST.Remove(playlist);
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

        // PUT: api/Users/notes/5?note=note&musique=id_musique
        [HttpPut("notes/{id}")]
        public async Task<ActionResult<User>> PutUserNotes(int id,
            [FromHeader] int note, [FromHeader] int musique)
        {
            if (note > 5 || note < 0)
            {
                return BadRequest(new Erreur("La note doit être compris entre 0 et 5 inclus"));
            }
            var note_user = await _context.NOTE
                .Where(a => a.id_user == id && a.id_musique == musique)
                .FirstOrDefaultAsync();
            if(note_user == null)
            {
                return NotFound(new Erreur("le user numéro : "+id+" n'a pas déjà mis de note à la musique numéro :"+musique));
            }
            note_user.note = note;
            _context.Entry(note_user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            var result = await _context.USER
                .Include(a => a.notes)
                //.ThenInclude(b => b.Musique) Pas besoin, déjà là pour playlist
                .Include(c => c.playlists)
                //.ThenInclude(d => d.Musique) lourd à la lecture, enelevé pour l'instant
                .Where(e => e.id_user == id)
                .FirstOrDefaultAsync();

            return Ok(result);
        }

        // POST : api/Users/playlist/copy/1?nom="string"&user=id_user
        // Copie une playlist d'un autre utilisateur id_user 
        [HttpPost("playlist/copy/{id}")]
        public async Task<ActionResult<User>> PostUserPlaylistCopie(int id,
            string nom, int user)
        {
            if (!UserExists(id))
            {
                return NotFound(new Erreur("User numéro: " + id + " inexistant"));
            }
            if (!UserExists(user))
            {
                return NotFound(new Erreur("User numéro: " + user + " inexistant"));
            }

            var playlists = await _context.PLAYLIST
                .Where(a => a.id_user == user && a.nom == nom)
                .ToListAsync();
            if (playlists == null)
            {
                return NotFound(new Erreur("Playlist nommé : "
                    + nom + " de l'utilisateur numéro: "
                    + id + ", introuvable"));
            }

            if (!playlists[0].publique)
            {
                return NotFound(new Erreur("Playlist nommé : "
                    + nom + " de l'utilisateur numéro: "
                    + id + " est privé"));
            }

            var existe = await _context.PLAYLIST
                .Where(a => a.id_user == id && a.nom == nom)
                .ToListAsync();
            if (existe != null)
            {
                return BadRequest(new Erreur("La playlist: "+nom+", existe déjà, impossible de copier"));
            }

            foreach(var playlist in playlists)
            {
                Playlist new_playlist = new Playlist()
                {
                    id_user = id,
                    id_musique = playlist.id_musique,
                    nom = playlist.nom
                };
                _context.PLAYLIST.Add(new_playlist);
            }

            await _context.SaveChangesAsync();

            var result = await _context.USER
                .Include(c => c.playlists)
                //.ThenInclude(d => d.Musique) lourd à la lecture, enelevé pour l'instant
                .Where(e => e.id_user == id)
                .FirstOrDefaultAsync();

            return Ok(result);
        }

        // POST : api/Users/playlist/import/1?album=id_album
        // Importe l'album en playlist nommé "playlist"+nom_album
        [HttpPost("playlist/import/{id}")]
        public async Task<ActionResult<User>> PostUserPlaylistImportAlbum(int id, int album)
        {
            if (!UserExists(id))
            {
                return NotFound(new Erreur("User numéro: " + id + " inexistant"));
            }

            var alb = await _context.ALBUM
                .Include(a => a.musiques)
                .Where(b => b.id_album == album)
                .FirstOrDefaultAsync();
            if (alb == null)
            {
                return NotFound(new Erreur("Album numéro: " + album + " inexistant"));
            }

            var existe = await _context.PLAYLIST
                .Where(a => a.id_user == id && a.nom == "playlist_"+alb.nom_album)
                .ToListAsync();
            if (existe != null)
            {
                return BadRequest(new Erreur("La playlist existe déjà, impossible d'importer"));
            }

            foreach (var musique in alb.musiques)
            {
                Playlist new_playlist = new Playlist()
                {
                    id_user = id,
                    id_musique = musique.id_musique,
                    nom = "playlist_" + alb.nom_album
                };
                _context.PLAYLIST.Add(new_playlist);
            }

            await _context.SaveChangesAsync();

            var result = await _context.USER
                .Include(c => c.playlists)
                //.ThenInclude(d => d.Musique) lourd à la lecture, enelevé pour l'instant
                .Where(e => e.id_user == id)
                .FirstOrDefaultAsync();

            return Ok(result);
        }
    }
}
