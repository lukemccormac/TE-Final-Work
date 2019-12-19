using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using Capstone.DAL.ReceiptInfo;
using Capstone.Models;
namespace Capstone.Tests
{
    [TestClass]
    public class ReceiptSQLDAOTests
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
        public void RecieptWriter_Should_Increase_Count_By_1()
        {
            Receipt receipt = new Receipt();
            receipt.SpaceID = 23;
            receipt.groupSize = 200;
            receipt.FromDate = new DateTime(2020, 10, 05);
            receipt.ToDate = new DateTime(2020, 10, 10);
            receipt.ReservedName = "Luke Smith"; 
            ReceiptSQLDAO dao = new ReceiptSQLDAO(ConnectionString);
            int startingRowCount = GetRowCount("reservation");

            dao.ReceiptWriter(receipt.SpaceID, receipt.groupSize, receipt.FromDate, receipt.ToDate,receipt.ReservedName );

            int endingRowCount = GetRowCount("reservation");
            Assert.AreEqual(startingRowCount + 1, endingRowCount);
        }
        protected int GetRowCount(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
        }
    }
}
