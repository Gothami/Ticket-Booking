using DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingDataLibrary.Models;

namespace TicketBookingDataLibrary.BusinessLogic
{
    public static class ShowsProcessor
    {
        public static int CreateShow(int ShowMovieID, int ShowTheatreID, List<DateTime> ShowTime)
        {
            ShowModel data = new ShowModel
            {
                showMovieID = ShowMovieID,
                showTheatreID = ShowTheatreID,
                showTime = ShowTime
            };

            string sql = @"insert into dbo.Shows (ShowMovieID, ShowTheatreID, MovieTime)
                           values (@showMovieID, @showTheatreID, @showTime);";

            return SQLDataAccess.SaveData(sql, data);
        }

        public static List<ShowModel> LoadShows()
        {
            string sql = @"select ShowMovieID, ShowTheatreID, ShowTime
                           from dbo.Shows;";

            return SQLDataAccess.LoadData<ShowModel>(sql);
        }
    }
}
