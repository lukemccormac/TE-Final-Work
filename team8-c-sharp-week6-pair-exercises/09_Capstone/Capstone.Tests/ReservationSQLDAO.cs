using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Models;
using Capstone.DAL.ReservationInfo;

namespace Capstone.Tests
{

    [TestClass]
    public class ReservationSQLDAOTests
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
        public void Spaces_That_Could_Be_Reserved()
        {
            ReservationSQLDAO dao = new ReservationSQLDAO(ConnectionString);

            DateTime startDate = new DateTime(2020, 10, 05);
            DateTime endDate = new DateTime(2020, 10, 10);
            IList<Reservation> result = dao.CheckReservation(startDate, endDate, 100, 5);
            Reservation venues = new Reservation();
            Assert.IsNotNull(result);


            DateTime startDate1 = new DateTime(2020, 01, 05);
            DateTime endDate1 = new DateTime(2020, 01, 10);
            IList<Reservation> result1 = dao.CheckReservation(startDate1, endDate1, 100000, 55);
            Reservation venues1 = new Reservation();
            Assert.AreEqual(result1.Count, 0);
        }
    }
}

