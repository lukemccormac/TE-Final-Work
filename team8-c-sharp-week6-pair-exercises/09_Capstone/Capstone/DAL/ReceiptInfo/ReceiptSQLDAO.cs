using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL.ReceiptInfo
{
    public class ReceiptSQLDAO : IReceiptDAO
    {
        private string connectionString;
        public ReceiptSQLDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }
        public Receipt ReceiptWriter(int spaceID, int groupSize, DateTime arrivalDate, DateTime leaveDate, string familyName)
        {
            Receipt receipt = new Receipt();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO reservation VALUES (@space_id, @number_of_attendees, @start_date, @end_date, @reserved_for);", conn);

                    cmd.Parameters.AddWithValue("@space_id", spaceID);
                    cmd.Parameters.AddWithValue("@number_of_attendees", groupSize);
                    cmd.Parameters.AddWithValue("@start_date", arrivalDate);
                    cmd.Parameters.AddWithValue("@end_date", leaveDate);
                    cmd.Parameters.AddWithValue("@reserved_for", familyName);
                    cmd.ExecuteNonQuery();
                    return receipt;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error saving Reservation.");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

