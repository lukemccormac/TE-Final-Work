using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL.ReservationInfo
{


    public class ReservationSQLDAO : IReservationDAO
    {
        private string connectionString;
        private string sql_GetAvailableSpaces = "SELECT top 5* FROM space s where venue_id= @venue_id" +

                " AND s.id NOT IN (SELECT s.id from reservation r JOIN space s on r.space_id = s.id" +
                " WHERE s.venue_id= @venue_id AND r.end_date >= @req_from_date AND r.start_date <= @req_to_date)";
        private string sql_GetSpacesReceipt = "SELECT * FROM space join venue on space.id = venue.id where space.id = @input1";
        public ReservationSQLDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }
        public IList<Reservation> CheckReservation(DateTime req_from_date, DateTime req_to_date, int numberOfAttendees, int input)
        {
            IList<Reservation> reservations = new List<Reservation>();
            {

            using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_GetAvailableSpaces, conn))
                    {
                        cmd.Parameters.AddWithValue("@venue_id", input);
                        cmd.Parameters.AddWithValue("@req_from_date", req_from_date);
                        cmd.Parameters.AddWithValue("@req_to_date", req_to_date);
                        cmd.Parameters.AddWithValue("@numberOfAttendees", numberOfAttendees);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Reservation reservation = ConvertReaderToAvailableReservations(reader);
                            reservations.Add(reservation);
                        }
                    }
                }
            }
            return reservations;
        }

        public Reservation ConvertReaderToAvailableReservations(SqlDataReader reader)
        {
            Reservation reservation = new Reservation();

            reservation.SpaceID = Convert.ToInt32(reader["id"]);
            reservation.VenueName = Convert.ToString(reader["name"]);
            reservation.DailyRate = Convert.ToInt32(reader["daily_rate"]);

            return reservation;
        }



    }



}

