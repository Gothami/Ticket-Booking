using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ticket_Booking.Startup))]
namespace Ticket_Booking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
