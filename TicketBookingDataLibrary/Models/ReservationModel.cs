using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingDataLibrary.Models
{
    public class ReservationModel
    {
        public int locationID { get; set; }
        public int noOfTickets { get; set; }
        public string seatZone { get; set; }
        public int movieID { get; set; } 
        public string date { get; set; }
        public int availableTickets { get; set; }

    }
}
