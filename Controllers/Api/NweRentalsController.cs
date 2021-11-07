using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly3.Dtos;
using Vidly3.Models;

namespace Vidly3.Controllers.Api
{
    public class NweRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NweRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Route("api/newrent")]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (newRental.MoviesId == null)
                return BadRequest("no movies have been given");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("customer does not exist");
            
            var movies = _context.Movies.Where(m => newRental.MoviesId.Contains(m.Id)).ToList();
            if (movies.Count != newRental.MoviesId.Count)
                return BadRequest("one or more movies are invalid");
            foreach (var movie in movies)
            {
                
                if (movie.NumberAvailable == 0)
                    return BadRequest("movie is not available");

                movie.NumberAvailable--;

                var newRentalRecord = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Today
                };
                
                _context.Rentals.Add(newRentalRecord);

            }

            _context.SaveChanges();
            
            return Ok();
        }
    }
}
