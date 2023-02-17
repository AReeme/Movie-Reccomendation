using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Recommendation.Data;
using Movie_Recommendation.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Movie_Recommendation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult RecommendMovie()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult RecommendMovie(Movie m)
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
            string x = User.FindFirstValue(ClaimTypes.Name);
            x = User.FindFirstValue(ClaimTypes.Email);
            x = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Content(x);
        }


        public IActionResult Moviequiz()
        {
            return View();
        }

        public IActionResult Snackquiz()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}