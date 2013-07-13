using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibNLP;

namespace Test.CorpusAnalyzer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNewNLPDocument()
        {
            // Create a document with 5 unique tokens
            NLPDocument doc = new NLPDocument("One two three four five", "Foo Document", new WhitespaceTokenizer());
            
            Assert.AreEqual(5, doc.TokenSet.Length);
        }

        [TestMethod]
        public void TestDocumentFromFile()
        {
        }
    }
}
