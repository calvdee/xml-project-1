using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibNLP
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
        private double _lexicalDiversity;

        private Dictionary<String, TokenStatistic> _tokenSet;
        private string[] _tokens;

        public TokenStatistic[] TokenSet { get { return _tokenSet.Values.ToArray(); } }
        public double LexicalDiversity { get { return _lexicalDiversity; } }

        public NLPDocument(string text, string name, DocumentTokenizer tokenizer) 
            : base(text, name) 
        {
            // Create the token set
            _tokenSet = new Dictionary<string, TokenStatistic>();

            // Get a list of tokens from the tokenizer
            _tokens = tokenizer.Tokenize(this);

            // Populate the token set
            foreach (string s in _tokens)
            {
                if (!_tokenSet.ContainsKey(s))
                {
                    // Add the token with default values
                    if (s.Length >= tokenizer.MinWordLen)
                        _tokenSet.Add(s, new TokenStatistic(1L, (ulong)s.Length, 1.0 / _tokens.Length, s));
                    
                    // Re-calculate lexical diveristy
                    _lexicalDiversity = _text.Length / (double)_tokenSet.Count;
                }
                else
                {
                    // Update the old values
                    TokenStatistic old = _tokenSet[s];
                    _tokenSet[s] = new TokenStatistic(
                        ++old.Frequency,
                        (ulong)s.Length,
                        old.Frequency / (double)_tokens.Length, s);
                }
            }
        }

        public TokenStatistic GetToken(string token)
        {
            if (!_tokenSet.ContainsKey(token)) throw new InvalidOperationException("Token does not exist");
            return _tokenSet[token];
        }
    }
}
