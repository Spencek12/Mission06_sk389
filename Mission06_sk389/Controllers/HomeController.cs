using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private MoviesContext blahContext { get; set; }
        
        //Constructors
        public HomeController(MoviesContext someName)
        {
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
            ViewBag.Categories = blahContext.Categories.ToList();
            //Instead of just returning the view, when adding, create a new movie
            return View("enterMovies", new ApplicationResponse());
        }
        [HttpPost]
        public IActionResult enterMovies(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                blahContext.Update(ar);
                blahContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else //if invalid
            {
                ViewBag.Categories = blahContext.Categories.ToList();
                return View(ar);
            }

        }
        // List movies
        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = blahContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ToList();
            return View(movies);
        }

        //Edit movies
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = blahContext.Categories.ToList();

            var movie = blahContext.Responses.Single(x => x.MovieId == id);

            return View("enterMovies", movie);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse blah)
        {
            blahContext.Update(blah);
            blahContext.SaveChanges();

            return RedirectToAction("Movielist");
        }

        //Delete movies
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = blahContext.Responses.Single(x => x.MovieId == id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            blahContext.Responses.Remove(ar);
            blahContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
