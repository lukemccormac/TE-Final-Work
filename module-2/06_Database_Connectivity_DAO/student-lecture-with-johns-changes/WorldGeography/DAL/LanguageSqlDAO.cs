using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class LanguageSqlDAO : ILanguageDAO
    {
        private string connectionString;

        private string sql_RemoveLanguage = "DELETE FROM countrylanguage WHERE " +
            "countrycode = @countryCode AND language = @name;";

        /// <summary>
        /// Creates a sql based language dao.
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public LanguageSqlDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public IList<Language> GetLanguages(string countryCode)
        {
            throw new NotImplementedException();
        }

        public bool AddNewLanguage(Language newLanguage)
        {
            throw new NotImplementedException();
        }

        public bool RemoveLanguage(Language deadLanguage)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql_RemoveLanguage, conn))
                    {

                        cmd.Parameters.AddWithValue("@countryCode", deadLanguage.CountryCode);
                        cmd.Parameters.AddWithValue("@name", deadLanguage.Name);

                        int count = cmd.ExecuteNonQuery();

                        if (count > 0)
                        {
                            result = true;
                        }

                    }
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
   
}
