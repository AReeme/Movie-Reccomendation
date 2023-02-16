using System.ComponentModel.DataAnnotations;

namespace Movie_Recommendation.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int? Year { get; set; }

        public float? Rating { get; set; }

        public string? ReleaseDate { get; set; }

        public string? Image { get; set; }

        public string? Genre { get; set; }

        public string? UserId { get; set; }

        public Movie()
        { }

        public Movie(string title, int? year, float? rating, string? release, string? image, string? genre)
        {
            Title = title;
            Year = year;
            Rating = rating;
            ReleaseDate = release;
            Image = image;
            Genre = genre;
        }
    }
}
