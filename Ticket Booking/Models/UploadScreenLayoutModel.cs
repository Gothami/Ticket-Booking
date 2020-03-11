using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Web;

namespace Ticket_Booking.Models
{
    public class UploadScreenLayoutModel
    {
        [Display(Name ="Screen Name")]
        public string ScreenName { get; set; }

        public byte[] screenLayout { get; set; }

        [Display(Name = "Seat Zones")]
        public string[] seatZones { get; set; }
    }
}