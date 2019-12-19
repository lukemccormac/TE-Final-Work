using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class CigarPartyTest
    {
        [TestMethod]
        public void HavePartyTest()
        {
            //haveParty(30, false) → false
            //haveParty(50, false) → true
            //haveParty(70, true) → true

            CigarParty cigarTest = new CigarParty();
            bool result = cigarTest.HaveParty(30, false);
            Assert.AreEqual(false, result);

            result = cigarTest.HaveParty(30, true);
            Assert.AreEqual(false, result); 

            result = cigarTest.HaveParty(50, false);
            Assert.AreEqual(true, result);

            result = cigarTest.HaveParty(50, true);
            Assert.AreEqual(true, result); 

            result = cigarTest.HaveParty(65, false);
            Assert.AreEqual(false, result); 

            result = cigarTest.HaveParty(65, true);
            Assert.AreEqual(true, result); 


        }
    }
}