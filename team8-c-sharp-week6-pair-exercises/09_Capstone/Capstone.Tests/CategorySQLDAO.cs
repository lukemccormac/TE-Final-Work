using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Models;
using Capstone.DAL.CategoryInfo;

namespace Capstone.Tests
{

    class CategorySQLDAOTests
    {
        [TestClass]
        public class CategorySqlDAOTests
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
            public void Get_All_Categories_Test()
            {
                CategorySQLDAO dao = new CategorySQLDAO(ConnectionString);

                IList<Category> result = dao.GetAllCategories(12);
                Category categories = new Category();;
                dao.GetAllCategories(12);
                IList<Category> result2 = dao.GetAllCategories(12);
                Assert.AreEqual(result.Count, result2.Count);

                IList<Category> result3 = dao.GetAllCategories(12);
                Category categories1 = new Category(); ;
                dao.GetAllCategories(12);
                IList<Category> result4 = dao.GetAllCategories(11);
                Assert.AreNotEqual(result3.Count, result4.Count);
            }
        }
    }
}

