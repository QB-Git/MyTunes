using Microsoft.EntityFrameworkCore;

namespace MyTunes.Models
{
    public class MusiqueContext : DbContext
    {
        public MusiqueContext(DbContextOptions<MusiqueContext> options)
            : base(options)
        {
        }

        public DbSet<Musique> MUSIQUE { get; set; }
    }
}