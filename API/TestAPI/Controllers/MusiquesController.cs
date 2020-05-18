using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
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
            var musiques = await _context.MUSIQUE
                .Include(a => a.pochette)
                .Include(b => b.editeur)
                .Include(c => c.artistes)
                    .ThenInclude(d => d.Artiste)
                .Include(e => e.genres)
                //.ThenInclude(f => f.Genre) Pose problèmes
                .Include(g => g.albums)
                //.ThenInclude(h => h.Album) Pose problème
                .Include(i => i.notes)
                //.ThenInclude(j => j.User) Pas de besoin de connaitre plus d'informations
                /*.Include(k => k.playlists)    Pas Besoin de connaitre les playlists dans lesquelles sont les musiques
                    .ThenInclude(l => l.User)*/
                .ToListAsync();

            return Ok(musiques);
        }

        // GET: api/Musiques/recherche/titre/"string"
        [HttpGet("recherche/titre/{titre}")]
        public async Task<ActionResult<IEnumerable<Musique>>> GetMUSIQUETitre(string titre)
        {
            var musiques = await _context.MUSIQUE
                .Include(a => a.pochette)
                .Include(b => b.editeur)
                .Include(c => c.artistes)
                    .ThenInclude(d => d.Artiste)
                .Include(e => e.genres)
                    //.ThenInclude(f => f.Genre) Pose problèmes
                .Include(g => g.albums)
                    //.ThenInclude(h => h.Album) Pose problème
                .Include(i => i.notes)
                //.ThenInclude(j => j.User) Pas de besoin de connaitre plus d'informations
                /*.Include(k => k.playlists)    Pas Besoin de connaitre les playlists dans lesquelles sont les musiques
                    .ThenInclude(l => l.User)*/
                .Where(s => s.titre.ToLower().Contains(titre.ToLower()))
                .ToListAsync();

            return Ok(musiques);
        }

        // GET: api/Musiques/recherche/artiste/"string"
        [HttpGet("recherche/artiste/{artiste}")]
        public async Task<ActionResult<IEnumerable<Musique>>> GetMUSIQUEArtiste(string artiste)
        {
            var musiques = await _context.MUSIQUE
                .Include(a => a.pochette)
                .Include(b => b.editeur)
                .Include(c => c.artistes)
                    .ThenInclude(d => d.Artiste)
                .Include(e => e.genres)
                //.ThenInclude(f => f.Genre) Pose problèmes
                .Include(g => g.albums)
                //.ThenInclude(h => h.Album) Pose problème
                .Include(i => i.notes)
                //.ThenInclude(j => j.User) Pas de besoin de connaitre plus d'informations
                /*.Include(k => k.playlists)    Pas Besoin de connaitre les playlists dans lesquelles sont les musiques
                    .ThenInclude(l => l.User)*/
                .Where(s => s.artistes.Any(s => s.Artiste.nom.ToLower().Contains(artiste.ToLower()) ||
                 s.Artiste.prenom.ToLower().Contains(artiste.ToLower())))
                .ToListAsync();

            return Ok(musiques);
        }

        // GET: api/Musiques/recherche/genre/"string"
        [HttpGet("recherche/genre/{genre}")]
        public async Task<ActionResult<IEnumerable<Musique>>> GetMUSIQUEGenre(string genre)
        {
            var musiques = await _context.MUSIQUE
                .Include(a => a.pochette)
                .Include(b => b.editeur)
                .Include(c => c.artistes)
                    .ThenInclude(d => d.Artiste)
                .Include(e => e.genres)
                //.ThenInclude(f => f.Genre) Pose problèmes
                .Include(g => g.albums)
                //.ThenInclude(h => h.Album) Pose problème
                .Include(i => i.notes)
                //.ThenInclude(j => j.User) Pas de besoin de connaitre plus d'informations
                /*.Include(k => k.playlists)    Pas Besoin de connaitre les playlists dans lesquelles sont les musiques
                    .ThenInclude(l => l.User)*/
                .Where(s => s.genres.Any(g => g.Genre.genre.ToLower().Contains(genre.ToLower())))
                .ToListAsync();

            return Ok(musiques);
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
                return NotFound(new Erreur("Musique numéro: "+id+"inexistante"));
            }

            return Ok(musique);
        }

        // GET: api/Musiques/moyenne/5
        [HttpGet("moyenne/{id}")]
        public async Task<ActionResult<int>> GetMoyMusique(int id)
        {
            var musique = await _context.MUSIQUE
                .Include(i => i.notes)
                .Where(m => m.id_musique == id)
                .FirstOrDefaultAsync();

            if (musique == null)
            {
                return NotFound(new Erreur("Musique numéro: " + id + "inexistante"));
            }

            var nombre = musique.notes.Count();
            double total = 0;
            foreach(var note in musique.notes)
            {
                total += note.note;
            }

            return Ok(total /= nombre);
        }

        // PUT: api/Musiques/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusique(int id, Musique musique)
        {
            if (id != musique.id_musique)
            {
                return BadRequest(new Erreur("Musique numéro: "+id+" inexsitante"));
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
                    return NotFound(new Erreur("Musique numéro: " + id + " inexsitante"));
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // PUT: api/Musiques/pochette/5
        [HttpPut("pochette/{id}")]
        public async Task<IActionResult> PutMusiquePochette(int id, int pochette)
        {
            if (!MusiqueExists(id))
            {
                return BadRequest(new Erreur("Musique numéro: " + id + " inexsitante"));
            }
            Musique musique = await _context.MUSIQUE
                .Include(a => a.pochette)
                .Include(b => b.editeur)
                .Include(c => c.artistes)
                    .ThenInclude(d => d.Artiste)
                .Include(e => e.genres)
                    .ThenInclude(f => f.Genre)
                .Include(g => g.albums)
                    .ThenInclude(h => h.Album)
                .Include(i => i.notes)
                .Where(c => c.id_musique == id)
                .FirstOrDefaultAsync();

            musique.pochette = await _context.POCHETTE.FindAsync(pochette);

            _context.Entry(musique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        // PUT: api/Musiques/editeur/5
        [HttpPut("editeur/{id}")]
        public async Task<IActionResult> PutMusiqueEditeur(int id, int editeur)
        {
            if (!MusiqueExists(id))
            {
                return BadRequest(new Erreur("Musique numéro: " + id + " inexsitante"));
            }
            Musique musique = await _context.MUSIQUE
                .Include(a => a.pochette)
                .Include(b => b.editeur)
                .Include(c => c.artistes)
                    .ThenInclude(d => d.Artiste)
                .Include(e => e.genres)
                    .ThenInclude(f => f.Genre)
                .Include(g => g.albums)
                    .ThenInclude(h => h.Album)
                .Include(i => i.notes)
                .Where(c => c.id_musique == id)
                .FirstOrDefaultAsync();

            musique.editeur = await _context.EDITEUR.FindAsync(editeur);

            _context.Entry(musique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        // POST: api/Musiques
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Musique>> PostMusique(Musique musique)
        {
            var changement = musique;
            changement.pochette = null;
            changement.editeur = null;
            changement.genres = null;
            changement.artistes = null;
            changement.albums = null;
            changement.notes = null;
            _context.MUSIQUE.Add(changement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusique", new { id = changement.id_musique }, changement);
        }

        // POST : api/musiques/genres/1
        // Ajout une liste de genres à l'album 1
        [HttpPost("genres/{id}")]
        public async Task<ActionResult<Musique>> PostMusiqueGenres(int id, [FromBody] IEnumerable<int> genres)
        {
            if (!MusiqueExists(id))
            {
                return NotFound(new Erreur("Musique numéro: " + id + " inexistante"));
            }
            foreach (var genre in genres)
            {
                if (!GenreExists(genre))
                {
                    return NotFound(new Erreur("Genre numéro: " + genre + " inexistant"));
                }
            }

            foreach (var genre in genres)
            {
                De_genre de = new De_genre()
                {
                    id_genre = genre,
                    id_musique = id
                };
                _context.DE_GENRE.Add(de);
            }
            await _context.SaveChangesAsync();

            var result = await _context.MUSIQUE
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

            return Ok(result);
        }

        // POST : api/musiques/artistes/1
        // Ajout une liste d'artistes à l'album 1
        [HttpPost("artistes/{id}")]
        public async Task<ActionResult<Musique>> PostMusiqueArtistes(int id, [FromBody] IEnumerable<int> artistes)
        {
            if (!MusiqueExists(id))
            {
                return NotFound(new Erreur("Musique numéro: " + id + " inexistante"));
            }
            foreach (var artiste in artistes)
            {
                if (!ArtisteExists(artiste))
                {
                    return NotFound(new Erreur("Artiste numéro: " + artiste + " inexistant"));
                }
            }

            foreach (var artiste in artistes)
            {
                A_fait fait = new A_fait()
                {
                    id_artiste = artiste,
                    id_musique = id
                };
                _context.A_FAIT.Add(fait);
            }
            await _context.SaveChangesAsync();

            var result = await _context.MUSIQUE
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

            return Ok(result);
        }

        // POST : api/musiques/albums/1
        // Ajouter une le titre dans une liste d'album
        [HttpPost("albums/{id}")]
        public async Task<ActionResult<Musique>> PostMusiqueAlbums(int id, [FromBody] IEnumerable<int> albums)
        {
            if (!MusiqueExists(id))
            {
                return NotFound(new Erreur("Musique numéro: " + id + " inexistante"));
            }
            foreach (var album in albums)
            {
                if (!GenreExists(album))
                {
                    return NotFound(new Erreur("Album numéro: " + album + " inexistant"));
                }
            }

            foreach (var album in albums)
            {
                Appartient_a a = new Appartient_a()
                {
                    id_album = album,
                    id_musique = id,
                    num_piste = _context.APPARTIENT_A
                                    .Where(a => a.id_album == album)
                                    .Count()
            };
                _context.APPARTIENT_A.Add(a);
            }
            await _context.SaveChangesAsync();

            var result = await _context.MUSIQUE
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

            return Ok(result);
        }
    }
}
