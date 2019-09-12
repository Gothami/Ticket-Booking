using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingDataLibrary.Models
{
    public class ShowModel
    {
        public int showMovieID { get; set; }
        public int showTheatreID { get; set; }
        public List<DateTime> showTime { get; set; }
    }
}
