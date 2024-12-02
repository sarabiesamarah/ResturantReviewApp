namespace ResturantReviewApp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }  // Primary Key
        public string Name { get; set; } = string.Empty;  // Avoid null warnings
        public string Location { get; set; } = string.Empty;  // Avoid null warnings
        public string CuisineType { get; set; } = string.Empty;  // Avoid null warnings
        public double Rating { get; set; }  // Default to 0
        public List<string> Reviews { get; set; } = new();  // Optional, only include if needed
    }
}

