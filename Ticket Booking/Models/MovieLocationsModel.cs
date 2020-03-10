using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticket_Booking.Models
{
    //ABOUT THIS CLASS : Theatres which shows particular movie
    public class MovieLocationsModel
    {
        public int ScreenID { get; set; }
        public string MovieName { get; set; }
        public string ScreenName { get; set; }
    }
}