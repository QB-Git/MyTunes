using Microsoft.EntityFrameworkCore;

namespace MyTunes.Models.Artiste
{
    public class ArtisteContext : DbContext
    {
        public ArtisteContext(DbContextOptions<ArtisteContext> options)
            : base(options)
        {
        }

        public DbSet<Artiste> ARTISTE { get; set; }
    }
}