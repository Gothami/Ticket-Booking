using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticket_Booking.Models
{
    public class MovieModel
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public Dictionary<string, List<DateTime>> MovieLocations { get; set; }
    }
}