using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Vidly3.Models;
using Vidly3.ViewModels;

namespace Vidly3.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies/random
        public ActionResult Random()
        {
            var movie = new Movie() {Id = 1, Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer {Name = "customer 1"},
                new Customer {Name = "customer 2"}

            };

            var viewModel = new RandomViewMovieModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Authorize(Roles = "CanManageMovies")]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var model = new MovieFormViewModel {Genres = genres, Movie = new Movie()};
            model.Movie.DateAdded = DateTime.Today;
            return View("MovieForm", model);
        }

        [Authorize(Roles = "CanManageMovies")]
        public ActionResult Edit(int id)
        {
            
            var model = new MovieFormViewModel
            {
                Movie = _context.Movies.SingleOrDefault(m => m.Id == id),
                Genres = _context.Genres.ToList()
            };
            if (model.Movie == null)
            {
                return HttpNotFound();
            }
            return View("MovieForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageMovies")]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var model = new MovieFormViewModel
                {
                    Genres = _context.Genres.ToList(),
                    Movie = movie
                };
                return View("MovieForm", model);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Index()
        {
            if (User.IsInRole("CanManageMovies"))
                return View("List");

            return View("ReadOnlyList");
        }

        [Route("movies/released/{year:regex(\\d{4}):range(2000,2100)}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }
    }

    
}