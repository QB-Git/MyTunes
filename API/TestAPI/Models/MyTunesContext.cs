using Microsoft.EntityFrameworkCore;

namespace MyTunes.Models
{
    public class MyTunesContext : DbContext
    {
        public MyTunesContext(DbContextOptions<MyTunesContext> options)
            : base(options)
        {
        }

        public DbSet<Album> ALBUM { get; set; }
        public DbSet<Artiste> ARTISTE { get; set; }
        public DbSet<Editeur> EDITEUR { get; set; }
        public DbSet<Genre> GENRE { get; set; }
        public DbSet<Musique> MUSIQUE { get; set; }
        public DbSet<Pochette> POCHETTE { get; set; }
        public DbSet<User> USER { get; set; }
    }
}