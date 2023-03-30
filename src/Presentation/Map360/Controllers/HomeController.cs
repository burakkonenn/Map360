using Map360.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Map360.Controllers
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
        
        public PartialViewResult Header()
        {

            return PartialView();
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}