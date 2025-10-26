using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace IPLabs.lab3.Models
{
    public class Sentence
    {
        [XmlElement("Token")]
        public List<Token> Tokens { get; } = new();

        [XmlIgnore] public int WordCount => Tokens.OfType<Word>().Count();
        
        [XmlIgnore] public int DisplayLength => ToString().Length;

        [XmlIgnore] public bool IsQuestion => ToString().TrimEnd().EndsWith("?");
        
        public override string ToString()
        {
            var result = string.Join(" ", Tokens.Select(t => t.Text));
            result = result.Replace(" ,", ",").Replace(" .", ".").Replace(" ?", "?");
            return result.Trim();
        }
    }
}