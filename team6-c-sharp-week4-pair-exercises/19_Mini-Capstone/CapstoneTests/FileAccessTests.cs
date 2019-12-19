using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using System.IO;

namespace Capstone.Tests
{
    [TestClass]
    public class FileAccessTests
    {
        AccessFiles accessFiles;

        [TestInitialize]
        public void Initialize()
        {
            accessFiles = new AccessFiles();
        }

        [TestMethod]
        public void WriteToLogTestAddMoney()
        {
            accessFiles.WriteToLog(100, 200.00M);
            using (StreamReader sr = new StreamReader("C:\\Catering\\Log.txt"))
            {
                Assert.IsTrue(sr.ReadToEnd().Contains(100.ToString()));
            }
        }

        [TestMethod]
        public void WriteToLogTestAddToCart()
        {
            accessFiles.WriteToLog(3, "Apple", "A4", 7.50D);
            using (StreamReader sr = new StreamReader("C:\\Catering\\Log.txt"))
            {
                Assert.IsTrue(sr.ReadToEnd().Contains("Apple"));
            }
        }

        [TestMethod]
        public void WriteToLogTestGetChange()
        {
            accessFiles.WriteToLog(3.00M);
            using (StreamReader sr = new StreamReader("C:\\Catering\\Log.txt"))
            {
                Assert.IsTrue(sr.ReadToEnd().Contains(3.00M.ToString()));
            }
        }
        [TestMethod]
        public void ReadFromFileTest()
        {
            accessFiles.ReadFromFile();
            using (StreamReader sr = new StreamReader("C:\\Catering\\cateringsystem.csv"))
            {
                Assert.IsNotNull(sr.ReadToEnd());
            }
        }
    }
}
