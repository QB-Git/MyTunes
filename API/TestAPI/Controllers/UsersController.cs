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
    public class UsersController : PatternnControllers
    {
        public UsersController(MyTunesContext context) :base(context)
        {
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUSER()
        {
            return await _context.USER.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.USER.FindAsync(id);

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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            //Faire en sorte que c'est le client ou l'API qui génère le token
            _context.USER.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.id_user }, user);
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
    }
}
