using Microsoft.EntityFrameworkCore;

namespace DatingApp.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AppUser>  AppUsers { get; set; }
    }
}
