using Microsoft.EntityFrameworkCore;

namespace MyTunes.Models.User
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