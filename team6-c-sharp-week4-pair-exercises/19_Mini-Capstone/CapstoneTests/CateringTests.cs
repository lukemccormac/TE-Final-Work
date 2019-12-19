using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace Capstone.Tests
{
    [TestClass]
    public class CateringTest
    {
        Catering catering;

        [TestInitialize]
        public void Initialize()
        {
            catering = new Catering();
        }

        [TestMethod]
        public void AddMoneyTest()
        {
            Assert.AreEqual(100, catering.AddMoney(100));
            Assert.AreEqual(300, catering.AddMoney(200));
            Assert.AreEqual(300, catering.AddMoney(0));
            Assert.AreEqual(300, catering.AddMoney(-100));
            Assert.AreEqual(300, catering.AddMoney(5000)); 
        }
        [TestMethod]
        public void ReturnChangeTest()
        {
            catering.AddMoney(100);
            catering.ReturnChange();
            Assert.IsTrue(catering.Change.ContainsKey("hundred dollar bill") && catering.Change.ContainsValue(1));

            catering.AddMoney(235);
            catering.ReturnChange();
            Assert.IsTrue(catering.Change.ContainsKey("twenty dollar bill") && catering.Change.ContainsValue(1));

            catering.AddMoney(576);
            catering.ReturnChange();
            Assert.IsTrue(catering.Change.ContainsKey("hundred dollar bills") && catering.Change.ContainsValue(5));


        }
    }
}
