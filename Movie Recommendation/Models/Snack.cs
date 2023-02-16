using System.ComponentModel.DataAnnotations;

namespace Movie_Recommendation.Models
{
    public class Snack
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public bool? isGlutenFree { get; set; }

        public string? UserId { get; set; }

        public Snack() {}

        public Snack(int id, string? name, string? type, bool? isGlutenFree)
        {
            Id = id;
            Name = name;
            Type = type;
            this.isGlutenFree = isGlutenFree;
        }
    }
}
