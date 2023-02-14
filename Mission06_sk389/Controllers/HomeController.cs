using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_sk389.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_sk389.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MoviesContext blahContext { get; set; }
        
        //Constructor
        public HomeController(ILogger<HomeController> logger, MoviesContext someName)
        {
            _logger = logger;
            blahContext = someName;
        }

        //Index page
        public IActionResult Index()
        {
            return View();
        }

        //Podcasts page
        [HttpGet]
        public IActionResult Podcasts()
        {
            return View();
        }
        //Enter movies page
        [HttpGet]
        public IActionResult enterMovies()
        {
            return View();
        }
        [HttpPost]
        public IActionResult enterMovies(ApplicationResponse ar)
        {
            blahContext.Add(ar);
            blahContext.SaveChanges();
            return View("Confirmation", ar);
        }

        public IActionResult Privacy()
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
