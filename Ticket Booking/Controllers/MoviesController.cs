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
            ViewBag.MovieName = movieName;
            return View();
        }
    }
}