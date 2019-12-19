using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class AnimalGroupNameTest
    {
         //* GetHerd("giraffe") → "Tower"
         //* GetHerd("") -> "unknown"         
         //* GetHerd("walrus") -> "unknown"
         //* GetHerd("Rhino") -> "Crash"
         //* GetHerd("rhino") -> "Crash"
         //* GetHerd("elephants") -> "unknown"
        [TestMethod]
        public void GetHerdTest()
        {
            //Arrange
            AnimalGroupName testClass = new AnimalGroupName();
            //Act
            string result = testClass.GetHerd("giraffe");
            //Assert
            Assert.AreEqual("Tower", result);

            result = testClass.GetHerd("");
            Assert.AreEqual("unknown", result);

            result = testClass.GetHerd("This is not an animal type");
            Assert.AreEqual("unknown", result);

            result = testClass.GetHerd("elephant");
            Assert.AreEqual("Herd", result); 
            

        }
        
    }
}
