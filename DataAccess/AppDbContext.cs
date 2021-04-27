using Microsoft.EntityFrameworkCore;
namespace KiproshBirthdayCelebration.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Associates> Associates { get; set; }
    }
}
