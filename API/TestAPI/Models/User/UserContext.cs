using Microsoft.EntityFrameworkCore;

namespace MyTunes.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> USER { get; set; }
    }
}