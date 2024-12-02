using Microsoft.EntityFrameworkCore;

namespace ResturantReviewApp.Models // Ensure the namespace matches your project
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
