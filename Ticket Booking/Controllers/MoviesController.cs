using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Ticket_Booking.Models;
using TicketBookingDataLibrary.BusinessLogic;

namespace Ticket_Booking.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        //Request data from API
        public ActionResult Index()
        {
            IEnumerable<MovieModel> movieList = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:47058/api/movie");
            var responseTask = client.GetAsync(client.BaseAddress);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<MovieModel>>();
                readTask.Wait();
                movieList = readTask.Result;
            }

            ViewBag.MovieList = movieList;
            return View();                
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

        [HttpGet]
        public ActionResult ReserveTickets(string movieName)
        {
            ReserveMovieModel model = new ReserveMovieModel();
            //List<string> movieLocation = new List<string>() { "Savoy", "Liberty", "Majestic City" };
            MovieTheatreModel savoy = new MovieTheatreModel() { TheatreID = 1, TheatreName = "Savoy" };
            MovieTheatreModel liberty = new MovieTheatreModel() { TheatreID = 2, TheatreName = "Liberty" };
            MovieTheatreModel mc = new MovieTheatreModel() { TheatreID = 3, TheatreName = "Majestic City" };

            List<MovieTheatreModel> movieLocation = new List<MovieTheatreModel>();
            movieLocation.Add(savoy);
            movieLocation.Add(liberty);
            movieLocation.Add(mc);

            SelectList ss = new SelectList(movieLocation, "TheatreID", "TheatreName");

            List<string> seatZone = new List<string>() {"A","B","C","D","E" };
            ViewBag.loc = ss;// new SelectList(movieLocation);
            ViewBag.zones = new SelectList(seatZone);
            ViewBag.movieName = movieName;



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReserveTickets(ReserveMovieModel movieName)
        {
            MovieTheatreModel savoy = new MovieTheatreModel() { TheatreID = 1, TheatreName = "Savoy" };
            MovieTheatreModel liberty = new MovieTheatreModel() { TheatreID = 2, TheatreName = "Liberty" };
            MovieTheatreModel mc = new MovieTheatreModel() { TheatreID = 3, TheatreName = "Majestic City" };

            List<MovieTheatreModel> movieLocation = new List<MovieTheatreModel>();
            movieLocation.Add(savoy);
            movieLocation.Add(liberty);
            movieLocation.Add(mc);

            SelectList ss = new SelectList(movieLocation, "TheatreID", "TheatreName");
            ViewBag.loc = ss;// new SelectList(movieLocation);

            List<string> seatZone = new List<string>() { "A", "B", "C", "D", "E" };
            ViewBag.zones = new SelectList(seatZone);


            ViewBag.MovieName = movieName;
            return RedirectToAction("Index");
        }

        
    }
}