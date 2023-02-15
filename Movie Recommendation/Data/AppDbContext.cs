using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie_Recommendation.Models;

namespace Movie_Recommendation.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Will Create the Movies Table in the db using Movie.cs Model
        public DbSet<Snack> Snacks { get; set; }
    }
}
