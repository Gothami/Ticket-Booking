using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticket_Booking.Models
{
    public class ReserveMovieModel
    {
        //[Display(Name = "Ticket Price")]
        //public List<int> ticketPrice { get; set; }

        [Display(Name = "Location")]
        public List<string> location { get; set; }

        [Display(Name = "Movie Date")]
        [DataType(DataType.Date)]
        public DateTime movieDate { get; set; }

        [Display(Name = "No of Tickets")]
        public int noOfTickets { get; set; }

        [Display(Name ="Seat Zone")]
        public List<string> seatZone { get; set; }
    }
}