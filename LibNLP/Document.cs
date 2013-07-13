using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibNLP
{
    public class Document
    {
        protected string _text;
        protected string _name;

        public string Name { get { return _name; } }
        public DateTime Created { get; set; }
        public string Text { get { return _text; } }

        public Document(string text, string name = "")
        {
            _text = text;
            _name = name;
        }
    }
}
