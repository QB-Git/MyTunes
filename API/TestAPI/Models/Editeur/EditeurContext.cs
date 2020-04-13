using Microsoft.EntityFrameworkCore;

namespace MyTunes.Models.Editeur
{
    public class EditeurContext : DbContext
    {
        public EditeurContext(DbContextOptions<EditeurContext> options)
            : base(options)
        {
        }

        public DbSet<Editeur> EDITEUR { get; set; }
    }
}