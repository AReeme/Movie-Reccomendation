using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Movie_Recommendation.Models
{
    public class Login
    {

        [Key]
        int id { get; set; }

        [Required]
        string loginName { get; set; }
        [Required]
        string password { get; set; }

        bool darkMode { get; set; }

        public Login() { }

        public Login(int id, string loginName, string password, bool darkMode)
        {
            this.id = id;
            this.loginName = loginName;
            this.password = password;
            this.darkMode = darkMode;
        }
    }
}
