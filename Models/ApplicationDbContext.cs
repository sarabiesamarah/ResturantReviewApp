using Microsoft.EntityFrameworkCore;

namespace ResturantReviewApp.Models // Ensure the namespace matches your project
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<Restaurant> Restaurants { get; set; }
    }
}
