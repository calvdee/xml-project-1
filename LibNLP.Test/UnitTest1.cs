using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibNLP;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace LibNLP.Test
{
    [TestClass]
    public class UnitTest1
    {
        public double TimeItSeconds(Action fn)
        {
            var sw = Stopwatch.StartNew();
            fn();
            return sw.ElapsedMilliseconds / 1000.0;
        }
        
        DocumentTokenizer tokenizer = new DocumentTokenizer() { MinWordLen = 3 };

        [TestMethod]
        public void TestNewNLPDocument()
        {
            // Create a document with 5 unique tokens
            NLPDocument doc = new NLPDocument("One two three four five", "Foo Document", new DocumentTokenizer());
            Assert.AreEqual(5, doc.TokenSet.Length);

            // Create a document with 1 valid token (
            NLPDocument docMinWordLen = 
                new NLPDocument(
                    "three three three a . f o oo", "Foo Document", 
                    tokenizer);

            Assert.AreEqual(docMinWordLen.TokenSet.Length, 1);
        }

        [TestMethod]
        public void TestStats()
        {
            string text = "two two three three three";
            double nTokens = tokenizer.Tokenize(text).Length;
            double freq = 2;

            NLPDocument doc = new NLPDocument(text, "Statistics", tokenizer);
            TokenStatistic token = doc.GetToken("two");

            Assert.AreEqual(token.PercentOccur, freq / nTokens);
        }

        [TestMethod]
        public void TestDocumentFromFile()
        {
            string path = "terminal_compromise.txt";
            string text = File.ReadAllText(path);
            FileInfo info = new FileInfo(path);

            // No min word length
            //NLPDocument docNoMinWordLen = new NLPDocument(text, "Terminal Compromise", new DocumentTokenizer());

            NLPDocument docMinWordLen = null;

            Action runTokenize = new Action(() => {
                docMinWordLen = new NLPDocument(text, "Terminal Compromise", tokenizer);
            });

            double elapsed = TimeItSeconds(runTokenize);

            Debug.WriteLine("--- LEXICAL DIVERSITY --" + Environment.NewLine);
            Debug.WriteLine("Elapsed: " + elapsed + " seconds");
            Debug.WriteLine("Each word used " + docMinWordLen.LexicalDiversity + "times on average");
            Debug.WriteLine("N Tokens: " + docMinWordLen.TokenSet.Length);
            Debug.WriteLine("MinWordLen: " + tokenizer.MinWordLen);
            Debug.WriteLine("Text Length: " + docMinWordLen.Text.Length);
            Debug.WriteLine(String.Format(new FileSizeFormatProvider(), 
                                         "File Size: {0:fs}", info.Length));

            Debug.Write(Environment.NewLine);

        }
    }
}
