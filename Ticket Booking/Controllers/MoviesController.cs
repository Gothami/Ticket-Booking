using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:47058/api/movie");

                var myContent = JsonConvert.SerializeObject(movieObject);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var responseTask = client.PostAsync(client.BaseAddress, byteContent).Result;
            }
            ModelState.Clear();
            ViewBag.Message = "Movie Added Successfully";

            return View();
        }

        [HttpGet]
        public ActionResult ReserveTickets(string movieName)
        {
            List<MovieTheatreModel> movieLocation = new List<MovieTheatreModel>();
            IEnumerable<ScreenModel> cinemaList = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:47058/api/screen");
            var responseTask = client.GetAsync(client.BaseAddress);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ScreenModel>>();
                readTask.Wait();
                cinemaList = readTask.Result;
            }

            foreach (ScreenModel screen in cinemaList)
            {
                MovieTheatreModel theatre = new MovieTheatreModel() { TheatreID = screen.ScreenID, TheatreName = screen.ScreenName };
                movieLocation.Add(theatre);
            }

            SelectList selectList = new SelectList(movieLocation, "TheatreID", "TheatreName");
            List<string> seatZone = new List<string>() {"A","B","C","D","E" };
            
            ViewBag.zones = new SelectList(seatZone);
            ViewBag.movieName = movieName;
            ViewBag.loc = selectList;

            return View();
        }

        [HttpPost]
        [ActionName("ReserveTicketsSubmit")]
        [ValidateAntiForgeryToken]
        public ActionResult ReserveTicketsSubmit(ReserveMovieModel movieModel, string MovieName)
        {
            int locationID = Int32.Parse(movieModel.location.FirstOrDefault());
            int noOfTickets = movieModel.noOfTickets;
            string zone = movieModel.seatZone.FirstOrDefault();
            DateTime time = movieModel.movieDate;
            int x = ReservationProcessor.ReserveTickets(locationID, MovieName.TrimEnd(), noOfTickets, zone, time);
            return RedirectToAction("Index");
        }        
    }
}