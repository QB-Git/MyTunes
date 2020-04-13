using Microsoft.EntityFrameworkCore;

namespace MyTunes.Models.Genre
{
    public class GenreContext : DbContext
    {
        public GenreContext(DbContextOptions<GenreContext> options)
            : base(options)
        {
        }

        public DbSet<Genre> GENRE { get; set; }
    }
}