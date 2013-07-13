using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusAnalyzer.Classes
{
    /// <summary>
    /// Generic tokenizer interface to interface objects of type <typeparamref name="T">
    /// </summary>
    /// <typeparam name="T">The type of object to tokenize</typeparam>
    public interface ITokenizer<T>
    {
        char Delimiter { get; }
        string[] Tokenize(T doc);
    }

    /// <summary>
    /// Specialized Tokenizer that tokenizes Documents.
    /// </summary>
    public class WhitespaceTokenizer : ITokenizer<Document>
    {
        public char Delimiter { get { return '\x20'; } }

        /// <summary>
        /// Returns a list of tokens, splitting the document on the delimiter.
        /// </summary>
        /// <param name="doc">The document containing the text to tokenize.</param>
        /// <returns>A collection of tokens.</returns>
        public string[] Tokenize(Document doc)
        {
            return doc.Text.Split(Delimiter );
        }
    }
}
