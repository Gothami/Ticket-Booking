using DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingDataLibrary.Models;

namespace TicketBookingDataLibrary.BusinessLogic
{
    public static class ReservationProcessor
    {
        public static int ReserveTickets(int locationID, string movieName, int noOfTickets, string seatZone, DateTime date)
        {
            int totalTickets = 0;
            string movieIDsql = @"SELECT MovieID FROM dbo.Movies WHERE MovieName = '" + movieName + "'";
            var dateOnly = date.ToShortDateString();
            int movieID = SQLDataAccess.GetMovieID<string>(movieIDsql);

            if(movieID > 0)
            {
                
                string sql = @"UPDATE dbo.Reservations SET AvailableTickets = AvailableTickets - " + noOfTickets +
                " WHERE (ShowMovieID = " + movieID + " AND ShowTheatreID = " + locationID + " AND SeatZone = '" + seatZone + "' AND MovieTime = '" + dateOnly + "')";

                int result = SQLDataAccess.UpdateNoOfTickets(sql);

                if(result <= 0)
                {
                    string NewSql = @"SELECT TotalTickets from dbo.ScreenZones WHERE ScreenZone_ScreenId = '" + locationID + "'";
                    totalTickets = SQLDataAccess.GetTotalTickets(NewSql);

                    int availableTickets = totalTickets - noOfTickets;
                    ReservationModel data = new ReservationModel
                    {
                        movieID = movieID,
                        locationID = locationID,
                        date = dateOnly,
                        seatZone = seatZone,
                        noOfTickets = noOfTickets,
                        availableTickets = availableTickets
                    };


                    string sqlUpdate = @"INSERT INTO dbo.Reservations (ShowMovieID, ShowTheatreID, MovieTime, SeatZone, NoOfTickets, AvailableTickets) 
                                        values (@movieID, @locationID,@date, @seatZone, @noOfTickets, @availableTickets)";
                    return SQLDataAccess.SaveData(sqlUpdate, data);
                }

                return result;

                


                
            }
            else
            {
                return -1;
            }
            
        }
    }
}
