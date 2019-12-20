using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Web;

namespace Ticket_Booking.Models
{
    public class UploadScreenLayoutModel
    {

        [Display(Name ="Screen Name")]
        public string ScreenName { get; set; }
        
        public Image uploadFile { get; set; }

    }
}