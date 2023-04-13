using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPad.Classes
{
    public class Document : ICloneable
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Document() { }
        public Document(string name, string text)
        {
            Name = name;
            Text = text;
        }
        public object Clone() => new Document()
        {
            Name = Name,
            Text = Text
        };
    }
}
