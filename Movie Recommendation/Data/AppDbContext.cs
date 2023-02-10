using Microsoft.EntityFrameworkCore;
using Movie_Recommendation.Models;
using System.Collections.Generic;

namespace Movie_Recommendation.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Will Create the Movies Table in the db using Movie.cs Model
        public DbSet<Movie> Movies { get; set; }
    }
}
