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
    public class EditeursController : GeneralControllers
    {
        public EditeursController(MyTunesContext context) :base(context)
        {
        }

        // GET: api/Editeurs?recherche="string"
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editeur>>> GetEDITEUR([FromHeader] string recherche)
        {
            var editeurs = await _context.EDITEUR.ToListAsync();
            if (!string.IsNullOrEmpty(recherche))
            {
                return Ok(editeurs.Where(s => s.nom_editeur.ToLower().Contains(recherche.ToLower())));
            }

            return Ok(editeurs);
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
        [HttpPost]
        public async Task<ActionResult<Editeur>> PostEditeur(Editeur editeur)
        {
            _context.EDITEUR.Add(editeur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditeur", new { id = editeur.id_editeur }, editeur);
        }
    }
}
