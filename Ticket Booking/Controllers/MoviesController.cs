using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket_Booking.Models;
using TicketBookingDataLibrary.BusinessLogic;

namespace Ticket_Booking.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View(ShowMovies());
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(MovieModel movieObject)
        {
            if (ModelState.IsValid)
            {
                MovieProcessor.CreateMovie(movieObject.MovieName, movieObject.MovieDescription);
            }
            return View();

        }

        public List<MovieModel> ShowMovies()
        {
            List<DataLibrary.Models.MovieModel> movies = MovieProcessor.RetrieveData();
            List<MovieModel> viewMovies= new List<MovieModel>();
            MovieModel movieModel = new MovieModel();

            foreach(DataLibrary.Models.MovieModel model in movies)
            {
                movieModel.MovieName = model.MovieName;
                movieModel.MovieDescription = model.MovieDescription;
                viewMovies.Add(movieModel);
            }

            return viewMovies;            
        }
    }
}