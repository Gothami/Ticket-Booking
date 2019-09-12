﻿using System;
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
        [Display(Name = "Movie ID")]
        [Range(1, 1000000)]
        public int MovieID { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Display(Name = "Movie Description")]
        public string MovieDescription { get; set; }

        [Display(Name = "Movie Theatres")]
        public List<string> MovieTheatres = new List<string>() { "Regal", "Savoy" };
        

        public MoviesController MyProperty { get; set; }
        public Dictionary<string, List<DateTime>> MovieLocations { get; set; }
    }
}