using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibNLP.Interface
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
}
