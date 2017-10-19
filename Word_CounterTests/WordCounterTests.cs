using Microsoft.VisualStudio.TestTools.UnitTesting;
using Word_Counter;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Counter.Tests
{
    [TestClass()]
    public class WordCounterTests
    {
        [TestMethod()]
        public void SplitTextTest()
        {
            string text = "My text. text1 word-to-word - ";
            string[] expected = { "my", "text", "text", "word-to-word" };

            string[] result = WordCounter.SplitText(text).ToArray();

            Assert.AreEqual(expected.Length, result.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod()]
        public void CreateWordsHashTableTest()
        {
            string[] collection = { "one", "one", "two", "four", "two" };
            Hashtable expectedTable = new Hashtable();
            expectedTable.Add("one", 2);
            expectedTable.Add("two", 2);
            expectedTable.Add("four", 1);

            Hashtable resultTable = WordCounter.CreateWordsHashTable(collection);

            foreach (var key in expectedTable.Keys)
            {
                Assert.AreEqual(expectedTable[key], resultTable[key]); 
            }
        }
    }
}