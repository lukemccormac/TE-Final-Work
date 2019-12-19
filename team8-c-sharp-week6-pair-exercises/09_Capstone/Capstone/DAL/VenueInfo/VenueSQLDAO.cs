using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL.VenueInfo
{
    public class VenueSQLDAO : IVenueDAO
    {
        private string connectionString;
        private string sql_GetVenues = "Select * from venue order by venue.name";
        private string Sql_GetVenue = "Select * From venue Where venue.id = @input"; 

        public VenueSQLDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }
        public IList<Venue> GetAllVenues()
        {
            IList<Venue> venues = new List<Venue>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_GetVenues, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Venue venue = ConvertReaderToVenue(reader);
                            venues.Add(venue);
                        }
                    }
                    return venues;
                }
            }
            catch (SqlException ex)
            {
                venues = new List<Venue>();
            }
            return venues;
        }

        public Venue GetVenue(int input)
        {
            Venue venue = new Venue();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql_GetVenue, conn))
                    {
                        cmd.Parameters.AddWithValue("@input", input);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Venue result = ConvertReaderToVenue(reader);
                            venue = result;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Venue result = new Venue();
            }
            return venue; 
        }
        public Venue ConvertReaderToVenue(SqlDataReader reader)
        {
            Venue venue = new Venue();

            venue.ID = Convert.ToInt32(reader["id"]);
            venue.Name = Convert.ToString(reader["name"]);
            venue.CityID = Convert.ToInt32(reader["city_id"]);
            venue.Description = Convert.ToString(reader["description"]);

            return venue;
        }
    }

}
