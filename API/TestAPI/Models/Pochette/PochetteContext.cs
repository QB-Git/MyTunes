using Microsoft.EntityFrameworkCore;

namespace MyTunes.Models.Pochette
{
    public class PochetteContext : DbContext
    {
        public PochetteContext(DbContextOptions<PochetteContext> options)
            : base(options)
        {
        }

        public DbSet<Pochette> POCHETTE { get; set; }
    }
}