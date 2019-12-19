using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private string connectionString;

        private string sql_GetCitiesByCountryCode = "SELECT * FROM city WHERE countrycode = @countryCode";


        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CitySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public void AddCity(City city)
        {
            throw new NotImplementedException();
        }

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            IList<City> cities = new List<City>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql_GetCitiesByCountryCode, conn))
                    {

                        cmd.Parameters.AddWithValue("@countryCode", countryCode);

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            City city = new City();

                            city.CityId = Convert.ToInt32(reader["id"]);
                            city.Name = Convert.ToString(reader["name"]);
                            city.District = Convert.ToString(reader["district"]);
                            city.CountryCode = Convert.ToString(reader["countrycode"]);
                            city.Population = Convert.ToInt32(reader["population"]);

                            cities.Add(city);
                        }
                    }
                }
            }
            catch
            {
                cities = new List<City>();
            }

            return cities;
        }
    }
}

