using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingDataLibrary.BusinessLogic
{
    public static class MovieProcessor
    {
        public static int CreateMovie(string movieName, string movieDescription)
        {
            MovieModel data = new MovieModel
            {
                
                MovieName = movieName,
                MovieDescription = movieDescription
            };

            string sql = @"insert into dbo.Movies(MovieName, MovieDescription) values (@MovieName, @MovieDescription);";

            return SQLDataAccess.SaveData(sql, data);
        }

        public static List<MovieModel> RetrieveData()
        {
            string sql = @"select * from dbo.Movies;";

            return SQLDataAccess.LoadData<MovieModel>(sql).ToList();
        }
    }
}
