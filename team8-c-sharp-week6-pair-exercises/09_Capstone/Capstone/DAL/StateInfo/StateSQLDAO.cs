using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL.StateInfo
{
    public class StateSQLDAO : IStateDAO
    {
        private string sql_GetLocation = "Select * from city join venue on city.id = venue.city_id Where venue.id = @input";
        private string connectionString;

        public StateSQLDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }
        public State GetLocation(int input)
        {
            State state = new State();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    using (SqlCommand cmd = new SqlCommand(sql_GetLocation, conn))
                    {
                        cmd.Parameters.AddWithValue("@input", input);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            State result = ConvertReaderToState(reader);
                            state = result;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                State result = new State();
            }
            return state;
        }
        public State ConvertReaderToState(SqlDataReader reader)
        {
            State state = new State();
            state.Name = Convert.ToString(reader["name"]);
            state.StateAbbreviation= Convert.ToString(reader["state_abbreviation"]);
            
            return state;
        }
    }
}
    
