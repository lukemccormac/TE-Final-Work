using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Voter.DAL.Interfaces;
using Voter.Models;

namespace Voter.DAL
{
    public class PersonDao : IPersonDao
    {
        string connectionString;

        string sql_GetPersons = "SELECT * FROM person;";

        public PersonDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>();

            try
            {



                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = sql_GetPersons;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        persons.Add(new Person
                        {
                            CountyId = Convert.ToString(reader["COUNTYID"]),
                            Registered = Convert.ToString(reader["REGISTERED"]),
                            LastName = Convert.ToString(reader["LASTNAME"]),
                            FirstName = Convert.ToString(reader["FIRSTNAME"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                persons = new List<Person>();
            }
            
            return persons;
        }
    }
}


