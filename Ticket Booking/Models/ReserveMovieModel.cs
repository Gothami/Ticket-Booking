using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticket_Booking.Models
{
    public class ReserveMovieModel
    {
        [Display(Name = "Ticket Price")]
        public List<int> ticketPrice { get; set; }

        [Display(Name = "Location")]
        public List<string> location { get; set; }

        ////[Display(Name = "Movie Location")]
        ////public List<string> movieLocation = new List<string>(){ "ss", "sss", "vvv" };//{ get; set; }

        [Display(Name = "Movie Time")]
        public List<DateTime> movieTime { get; set; }

        [Display(Name = "No of Tickets")]
        public int noOfTickets { get; set; }

        [Display(Name ="Seat Zone")]
        public List<int> seatZone { get; set; }
    }
}