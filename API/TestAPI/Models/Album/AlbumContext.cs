using Microsoft.EntityFrameworkCore;

namespace MyTunes.Models
{
    public class AlbumContext : DbContext
    {
        public AlbumContext(DbContextOptions<AlbumContext> options)
            : base(options)
        {
        }

        public DbSet<Album> ALBUM { get; set; }
    }
}