using Microsoft.EntityFrameworkCore;

namespace MyTunes.Models
{
    public class MyTunesContext : DbContext
    {
        public MyTunesContext(DbContextOptions<MyTunesContext> options)
            : base(options)
        {
        }

        public DbSet<A_fait> A_FAIT { get; set; }
        public DbSet<Album> ALBUM { get; set; }
        public DbSet<Appartient_a> APPARTIENT_A { get; set; }
        public DbSet<Artiste> ARTISTE { get; set; }
        public DbSet<De_genre> DE_GENRE { get; set; }
        public DbSet<Editeur> EDITEUR { get; set; }
        public DbSet<Genre> GENRE { get; set; }
        public DbSet<Musique> MUSIQUE { get; set; }
        public DbSet<Note> NOTE { get; set; }
        public DbSet<Playlist> PLAYLIST { get; set; }
        public DbSet<Pochette> POCHETTE { get; set; }
        public DbSet<User> USER { get; set; }
    }
}