using Microsoft.Extensions.Primitives;

using System.ComponentModel.DataAnnotations;

namespace Movie_Recommendation.Models
{
    public class Login
    {

        [Key]
        int id { get; set; }

        [Required]
        string userName { get; set; }
        [Required]
        string password { get; set; }

        bool darkMode { get; set; }

        public Login() { }

        public Login(int id, string userName, string password, bool darkMode)
        {
            this.id = id;
            this.userName = userName;
            this.password = password;
            this.darkMode = darkMode;
        }

        public override string ToString()
        {
            return @"(userName) - (password) - (darkMode)";
        }
    }
}
