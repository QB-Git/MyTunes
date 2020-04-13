using Microsoft.EntityFrameworkCore;
using MyTunes.Models;

namespace TodoApi.Models
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