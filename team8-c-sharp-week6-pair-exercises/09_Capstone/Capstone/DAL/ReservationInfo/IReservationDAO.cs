using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL.ReservationInfo
{
    public interface IReservationDAO
    {
        IList<Reservation> CheckReservation(DateTime start_date, DateTime end_date, int numberOfAttendees, int input);

        //Reservation BookReservation();

        //Reservation Receipt();
    }
}
