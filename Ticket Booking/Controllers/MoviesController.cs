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
        [HttpGet]
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
        public ActionResult AddMovie(string[] DynamicTextBox, MovieModel movieObject)
        {
            if (ModelState.IsValid)
            {
                foreach(string cinema in DynamicTextBox)
                    movieObject.MovieTheatres.Add(cinema);

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

        //Call API's ScreenController/GetScreenNames()
        [HttpGet]
        public ActionResult ReserveTickets(string movieName)
        {
            List<MovieTheatreModel> movieLocation = new List<MovieTheatreModel>();
            IEnumerable<MovieLocationsModel> cinemaList = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:47058/api/screen?movieName=" + movieName);
            var responseTask = client.GetAsync(client.BaseAddress);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<MovieLocationsModel>>();
                readTask.Wait();
                cinemaList = readTask.Result;
            }

            foreach (MovieLocationsModel screen in cinemaList)
            {
                MovieTheatreModel theatre = new MovieTheatreModel() { TheatreID = screen.ScreenID, TheatreName = screen.ScreenName };
                movieLocation.Add(theatre);
            }

            SelectList selectList = new SelectList(movieLocation, "TheatreID", "TheatreName");

            List <string> seatZone = new List<string>();
            
            ViewBag.zones = new SelectList(seatZone);
            ViewBag.movieName = movieName;
            ViewBag.loc = selectList;

            return View();
        }

        //TODO: Get data from Web API
        [HttpPost]
        [ActionName("ReserveTicketsSubmit")]
        [ValidateAntiForgeryToken]
        public ActionResult ReserveTicketsSubmit(ReserveMovieModel movieModel, string MovieName)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:47058/api/reservation");
            movieModel.movieName = MovieName;
            var myContent = JsonConvert.SerializeObject(movieModel);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseTask = client.PostAsync(client.BaseAddress, byteContent).Result;

            ModelState.Clear();

            return RedirectToAction("Index");
        }        
    }
}