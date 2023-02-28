﻿using Microsoft.AspNetCore.Authorization;
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

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        IDataAccessLayerSnack dal;
        public HomeController(IDataAccessLayerSnack indal)
        {
            dal = indal;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MovieRecommend()
        {
            string movieId = "315162";
            var movie = await client.GetAsync(url + movieId + "?api_key=" + key);
            if (movie.IsSuccessStatusCode)
            {
                Movie rMovie = JsonConvert.DeserializeObject<Movie>(await client.GetStringAsync(url + movieId + "?api_key=" + key));
                string name = rMovie.Title;
                
                return View("MovieRecommend", name);
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

        public IActionResult SnackFilter(string name, string type, string isGlutenFree)
        {
            return View("snackquiz", dal.FilterSnacks(name, type, isGlutenFree));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}