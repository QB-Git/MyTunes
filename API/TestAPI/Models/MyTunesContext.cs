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

        //On ne peut utiliser les Annontations pour les tables avec plusieurs clés primaires et pour les relations many-to-many, on doit le faire en Fluent API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<A_fait>().HasKey(sc => new { sc.id_artiste, sc.id_musique });
            builder.Entity<A_fait>()
                .HasOne(pt => pt.Artiste)
                .WithMany(p => p.musiques)
                .HasForeignKey(pt => pt.id_artiste);
            builder.Entity<A_fait>()
                .HasOne(pt => pt.Musique)
                .WithMany(t => t.artistes)
                .HasForeignKey(pt => pt.id_musique);

            builder.Entity<Appartient_a>().HasKey(sc => new { sc.id_musique, sc.id_album });
            builder.Entity<Appartient_a>()
                .HasOne(pt => pt.Musique)
                .WithMany(p => p.albums)
                .HasForeignKey(pt => pt.id_musique);
            builder.Entity<Appartient_a>()
                .HasOne(pt => pt.Album)
                .WithMany(t => t.musiques)
                .HasForeignKey(pt => pt.id_album);

            builder.Entity<De_genre>().HasKey(sc => new { sc.id_musique, sc.id_genre });
            builder.Entity<De_genre>()
                .HasOne(pt => pt.Musique)
                .WithMany(p => p.genres)
                .HasForeignKey(pt => pt.id_musique);
            builder.Entity<De_genre>()
                .HasOne(pt => pt.Genre)
                .WithMany(t => t.musiques)
                .HasForeignKey(pt => pt.id_genre);

            builder.Entity<Note>().HasKey(sc => new { sc.id_user, sc.id_musique });
            builder.Entity<Note>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.notes)
                .HasForeignKey(pt => pt.id_user);
            builder.Entity<Note>()
                .HasOne(pt => pt.Musique)
                .WithMany(t => t.notes)
                .HasForeignKey(pt => pt.id_musique);

            builder.Entity<Playlist>().HasKey(sc => new { sc.id_user, sc.id_musique, sc.nom });
            builder.Entity<Playlist>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.playlists)
                .HasForeignKey(pt => pt.id_user);
            /*builder.Entity<Playlist>()                Pas besoin
                .HasOne(pt => pt.Musique)
                .WithMany(t => t.playlists)
                .HasForeignKey(pt => pt.id_musique);*/
        }
    }
}