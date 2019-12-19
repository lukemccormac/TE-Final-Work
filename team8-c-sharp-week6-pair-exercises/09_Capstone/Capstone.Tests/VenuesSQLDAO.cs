using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Models;
using Capstone.DAL.VenueInfo;

namespace Capstone.Tests
{

    [TestClass]
    public class VenueSQLDAOTests
    {

        protected string ConnectionString { get; } = "Data Source=.\\sqlexpress;Initial Catalog=excelsior_venues;Integrated Security=True";

        private TransactionScope transaction;

        [TestInitialize]
        public void Setup()
        {
            transaction = new TransactionScope();
        }
        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void Get_All_Venues_Tests()
        {
            VenueSQLDAO dao = new VenueSQLDAO(ConnectionString);

            IList<Venue> result = dao.GetAllVenues();
            Venue venues = new Venue();
            Assert.AreEqual(result.Count, 15);
        }

        [TestMethod]
        public void Get_One_Venue_Test()
        {
            VenueSQLDAO dao = new VenueSQLDAO(ConnectionString);

            Venue result1 = dao.GetVenue(12);
            Venue venues = new Venue();
            Assert.IsNotNull(result1); 
        }
    }
}

