using LibNLP.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibNLP
{
    /// <summary>
    /// Tokenizer providing functionality to tokenize a string, splitting it using
    /// a whitespace delimiter.
    /// </summary>
    public class WhitespaceTokenizer : ITokenizer<string>
    {
        public char Delimiter { get { return '\x20'; } }
        public int MinWordLen { get; set; }

        /// <summary>
        /// Returns a list of tokens, splitting the text on the delimiter.
        /// </summary>
        /// <param name="doc">The string containing the text to tokenize.</param>
        /// <returns>A collection of tokens.</returns>
        public string[] Tokenize(string text)
        {
            return text.Split(Delimiter);
        }
    }

    public class DocumentTokenizer : WhitespaceTokenizer, ITokenizer<Document>
    {

        /// <summary>
        /// Returns a list of tokens, splitting the document on the delimiter.
        /// </summary>
        /// <param name="doc">The document containing the text to tokenize.</param>
        /// <returns>A collection of tokens.</returns>
        public string[] Tokenize(Document doc)
        {
            return base.Tokenize(doc.Text);
        }
    }

}
