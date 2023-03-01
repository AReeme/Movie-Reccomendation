using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Recommendation.Data;
using Movie_Recommendation.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Net.Http;
using Newtonsoft.Json;
using Movie_Recommendation.Interface;

namespace Movie_Recommendation.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient client = new HttpClient();
        private string key = "864f586643a869865bfc9ec19ca5fdba";
        private string url = "https://api.themoviedb.org/3/movie/";

        IDataAccessLayerSnack dal;
        public HomeController(IDataAccessLayerSnack indal)
        {
            dal = indal;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MovieRecommend(string genre, string genre1,string genre2, string genre3, string genre4, string hateGenre, string hateGenre1, string hateGenre2, string hateGenre3, string hateGenre4, int age, int rating)
        {
            //will create a string to search genres in the api key
            string adult="";
            string[] genres = { genre, genre1, genre2, genre3, genre4 };
            string genresKey = "";
            string genresKeyCheck = "";
            for(int i = 0; i < genres.Count(); i++) //might have to take out the = sign near genres.count()
            {
                if (genres[i] != null)
                {
                    genresKey += genres[i];
                    genresKeyCheck+= genres[i];
                    if(i < genres.Count() - 1)
                    {
                        genresKey += "%20";
                    }
                }
                else
                {
                    continue;
                }
            }
            string[] hateGenres = { hateGenre, hateGenre1, hateGenre2, hateGenre3, hateGenre4 };
            string hateGenresKey = "";
            string hateGenresKeyCheck = "";
            for (int i = 0; i < hateGenres.Count(); i++) //might have to take out the = sign near genres.count()
            {
                if (hateGenres[i] != null)
                {
                    hateGenresKey += hateGenres[i];
                    hateGenresKeyCheck+= hateGenres[i];
                    if (i < hateGenres.Count() - 1)
                    {
                        genresKey += "%20";
                    }
                }
                else
                {
                    continue;
                }
            }
            if(age >= 18)
            {
                adult = "true";
            }
            else
            {
                adult = "false";
            }
            string movieId = "76600";
            var movie = await client.GetAsync(url + movieId + "?api_key=" + key);
            if (movie.IsSuccessStatusCode)
            {
                Movie rMovie = JsonConvert.DeserializeObject<Movie>(await client.GetStringAsync(url + "discover/movie" + "?api_key=" + key + "&language=en-US&include_adult=" + adult + "&vote_average.gte=" + rating + "&with_genres=" + genresKey + "&without_genres=" + hateGenresKey));


                return View("MovieRecommend", rMovie);
            }
 
                return Content("this did not work stupid");
        }

        [Authorize]
        [HttpPost]
        public IActionResult MovieRecommend(Movie m)
        {
            if (ModelState.IsValid)
            {
                m.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult RecommendSnack()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult RecommendSnack(Snack s)
        {
            if(ModelState.IsValid)
            {
                s.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Moviequiz()
        {
            return View();
        }

        public IActionResult Snackquiz()
        {
            return View();
        }

        public IActionResult SnackFilter(string? name, string? type, string? isglutenfree)
        {
            return View("snackquiz", dal.FilterSnacks(name, type, isglutenfree));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}