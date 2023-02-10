using Microsoft.AspNetCore.Mvc;

namespace Movie_Recommendation.Controllers
{
    public class SnackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
