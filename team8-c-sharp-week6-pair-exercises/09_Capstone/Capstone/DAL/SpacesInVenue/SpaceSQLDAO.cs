using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL.SpaceInVenue
{
    public class SpaceSQLDAO : ISpaceDAO
    {
        private string connectionString;
        private string sql_GetAllSpaces = "SELECT * FROM space where venue_id = @input";
        public SpaceSQLDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }
        public IList<Space> GetAllSpaces(int input)
        {
            IList<Space> spaces = new List<Space>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_GetAllSpaces, conn))
                    {
                        cmd.Parameters.AddWithValue("@input", input);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Space space = ConvertReaderToSpace(reader);
                            spaces.Add(space);
                        }
                    }
                    return spaces;
                }

            }
            catch (SqlException ex)
            {
              spaces = new List<Space>();
            }
            return spaces;
        }
        public Space ConvertReaderToSpace(SqlDataReader reader)
        {
            Space space = new Space();

            space.ID = Convert.ToInt32(reader["id"]);
            space.VenueID = Convert.ToInt32(reader["venue_id"]);
            space.Name = Convert.ToString(reader["name"]);
            space.IsAccessible = Convert.ToBoolean(reader["is_accessible"]);
            space.OpenFrom = Convert.ToString(reader["open_from"]);
            space.OpenTo = Convert.ToString(reader["open_to"]);
            space.DailyRate = Convert.ToDecimal(reader["daily_rate"]);
            space.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);

            return space;
        }
        



    }
}
