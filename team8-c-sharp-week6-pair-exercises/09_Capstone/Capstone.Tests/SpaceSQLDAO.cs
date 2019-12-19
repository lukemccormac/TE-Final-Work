using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Models;
using Capstone.DAL.SpaceInVenue;

namespace Capstone.Tests
{
    
        [TestClass]
    public class SpaceSQLDAOTests
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
        public void Get_All_Spaces_Tests()
        {
            SpaceSQLDAO dao = new SpaceSQLDAO(ConnectionString);

            IList<Space> result = dao.GetAllSpaces(12);
            Space spaces = new Space();
            dao.GetAllSpaces(12);
            IList<Space> result2 = dao.GetAllSpaces(12);
            Assert.AreEqual(result.Count, result2.Count);

            IList<Space> result3 = dao.GetAllSpaces(9);
            Space categories1 = new Space(); ;
            dao.GetAllSpaces(12);
            IList<Space> result4 = dao.GetAllSpaces(11);
            Assert.AreNotEqual(result3.Count, result4.Count);
        }
    }
}   




