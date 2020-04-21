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
    public class GenresController : GeneralControllers
    {
        public GenresController(MyTunesContext context) : base(context)
        {
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGENRE()
        {
            return await _context.GENRE
                .Include(a => a.musiques)
                    .ThenInclude(b => b.Musique)
                .ToListAsync();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _context.GENRE
                .Include(a => a.musiques)
                    .ThenInclude(b => b.Musique)
                .Where(c => c.id_genre == id)
                .FirstOrDefaultAsync();

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }
    }
}
