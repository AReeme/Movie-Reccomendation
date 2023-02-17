using System.ComponentModel.DataAnnotations;

namespace Movie_Recommendation.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string ImdbId { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Overview { get; set; }
        public string Homepage { get; set; }

        public string BackdropPath { get; set; }
        public string PosterPath { get; set; }

        public bool Adult { get; set; }

        public List<string> BelongsToCollection { get; set; }
        public List<Object> Genres { get; set; }

        public DateTime ReleaseDate { get; set; }
        public long Revenue { get; set; }
        public long Budget { get; set; }
        public int Runtime { get; set; }

        public double Popularity { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }

        public List<string> ProductionCompanies { get; set; }
        public List<string> ProductionCountries { get; set; }
        public List<string> SpokenLanguages { get; set; }

        public string AlternativeTitles { get; set; }
        public string Releases { get; set; }
        public string Casts { get; set; }
        public string Images { get; set; }
        public string Keywords { get; set; }
        public string Trailers { get; set; }
        public string Translations { get; set; }
        public string SimilarMovies { get; set; }
        public string SearchContainer { get; set; }
        public List<string> Changes { get; set; }
        public string? UserId { get; set; }

    }
}
