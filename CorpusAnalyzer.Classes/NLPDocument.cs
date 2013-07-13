using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusAnalyzer.Classes
{
    public struct TokenStatistic
    {
        public string Name;
        public ulong Frequency;
        public ulong Length;
        public double PercentOccur;

        public TokenStatistic(ulong f, ulong l, double p, string n)
        {
            Frequency = f;
            Length = l;
            PercentOccur = p;
            Name = n;
        }
    }

    public class NLPDocument : Document
    {

        //private uint WordCount { get; set; }
        //private double _lexicalDiversity;

        private Dictionary<String, TokenStatistic> _tokenSet;
        private String[] _tokens;

        // Immutable list?
        public Dictionary<String, TokenStatistic> TokensSet { get { return _tokenSet; } }

        public NLPDocument(string text, string name, WhitespaceTokenizer tokenizer) 
            : base(text, name) 
        {
            // Create the token set
            _tokenSet = new Dictionary<string, TokenStatistic>();

            // Get a list of tokens from the tokenizer
            _tokens = tokenizer.Tokenize(this);

            // Populate the token set
            foreach (String s in _tokens)
            {
                if (!_tokenSet.ContainsKey(s)) // Add the token with default values
                    _tokenSet.Add(s, new TokenStatistic(1L, (ulong)s.Length, 1.0 / _text.Length, s));
                else
                {
                    // Update the old values by replacing the struct
                    TokenStatistic old = _tokenSet[s];
                    _tokenSet[s] = new TokenStatistic(++old.Frequency, (ulong)s.Length, old.Frequency / (double)_text.Length, s);
                }
            }
        }
    }
}
