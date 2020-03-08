using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket_Booking.Controllers;

namespace Ticket_Booking.Models
{
    public class MovieModel
    {
        [Required]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Display(Name = "Movie Description")]
        public string MovieDescription { get; set; }

        [Display(Name = "Movie Theatres")]
        public List<string> MovieTheatres = new List<string>(); //{ "Regal", "Savoy" };        

        public Dictionary<string, List<DateTime>> MovieLocations { get; set; }
    }
}