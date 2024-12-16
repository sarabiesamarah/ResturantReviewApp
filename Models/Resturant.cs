namespace ResturantReviewApp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }             // Primary key
        public string Name { get; set; } = ""; // Avoid null issues
        public string Location { get; set; } = ""; // Avoid null issues
        public string Cuisine { get; set; } = "";  // Avoid null issues
        public double Rating { get; set; } = 0.0;  // Default value for Rating
    }
}



