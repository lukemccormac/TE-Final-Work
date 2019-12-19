using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL.VenueInfo
{
    public interface IVenueDAO
    {
        //Get All Venues
        IList<Venue> GetAllVenues();

        //Get Single Venue
        Venue GetVenue(int ID);
    }
}
