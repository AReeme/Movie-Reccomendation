using System.ComponentModel.DataAnnotations;

namespace Movie_Recommendation.Models
{
    public class MovieResults
    {
        [Key]
        public int Id { get; set; }
        public int Page { get; set; }
        public Object[] Results { get; set; }
        public int Total_Results { get; set; }
        public int Total_Pages { get; set; }

    }
}
