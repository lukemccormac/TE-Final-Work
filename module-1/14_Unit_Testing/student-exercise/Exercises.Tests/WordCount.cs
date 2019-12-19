using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Exercises.Tests
{
    [TestClass]
    public class WordCountTest
    {
        [TestMethod]
        public void GetCount()
        {
            //*Given an array of strings, return a Dictionary<string, int> with a key for each different string, with the value the
            //* number of times that string appears in the array.
            //*GetCount(["ba", "ba", "black", "sheep"]) → { "ba" : 2, "black": 1, "sheep": 1 }
            //*GetCount(["a", "b", "a", "c", "b"]) → { "b": 2, "c": 1, "a": 2}
            //*GetCount([]) → { }
            //*GetCount(["c", "b", "a"]) → { "b": 1, "c": 1, "a": 1}

        WordCount newTest = new WordCount();
        Dictionary<string, int> newAnswers = new Dictionary<string, int>();
            newAnswers.Add("ba", 2);
            newAnswers.Add("black", 1);
            newAnswers.Add("sheep", 1); 
        Dictionary<string, int> result = newTest.GetCount(new string[]{ "ba", "ba", "black", "sheep"});
        CollectionAssert.AreEqual(newAnswers, result);

        Dictionary<string, int> newAnswers1 = new Dictionary<string, int>();
            newAnswers1.Add("ka", 2);
            newAnswers1.Add("", 1);
            newAnswers1.Add("eep", 1);
        Dictionary<string, int> result1 = newTest.GetCount(new string[] { "ka", "ka", "", "eep" });
        CollectionAssert.AreEqual(newAnswers1, result1);
        }
    }
}