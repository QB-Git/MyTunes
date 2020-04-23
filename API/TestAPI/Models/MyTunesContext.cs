using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MyTunes.Models
{
    public class MyTunesContext : DbContext//, IMyTunesContext
    {
        public MyTunesContext(DbContextOptions<MyTunesContext> options)
            : base(options)
        {
        }

        //Les DbSet sont en virtual pour pouvoir de mocker (simuler/imiter) le framework et mettre en place une implementation mocker
        public virtual DbSet<A_fait> A_FAIT { get; set; }
        public virtual DbSet<Album> ALBUM { get; set; }
        public virtual DbSet<Appartient_a> APPARTIENT_A { get; set; }
        public virtual DbSet<Artiste> ARTISTE { get; set; }
        public virtual DbSet<De_genre> DE_GENRE { get; set; }
        public virtual DbSet<Editeur> EDITEUR { get; set; }
        public virtual DbSet<Genre> GENRE { get; set; }
        public virtual DbSet<Musique> MUSIQUE { get; set; }
        public virtual DbSet<Note> NOTE { get; set; }
        public virtual DbSet<Playlist> PLAYLIST { get; set; }
        public virtual DbSet<Pochette> POCHETTE { get; set; }
        public virtual DbSet<User> USER { get; set; }

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