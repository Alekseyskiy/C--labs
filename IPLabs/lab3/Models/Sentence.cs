using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace IPLabs.lab3.Models
{
    
    [XmlInclude(typeof(Word))]
    [XmlInclude(typeof(Punctuation))]
    public class Sentence
    {
        [XmlArray("Tokens")]
        [XmlArrayItem("Word", typeof(Word))]
        [XmlArrayItem("Punctuation", typeof(Punctuation))]
        public List<object> Tokens { get; } = new();

        [XmlIgnore] public int WordCount => Tokens.OfType<Word>().Count();
        
        [XmlIgnore] public int DisplayLength => ToString().Length;

        [XmlIgnore] public bool IsQuestion => ToString().TrimEnd().EndsWith("?");
        
        public override string ToString()
        {
            var result = string.Join(" ", Tokens.Select(t =>
            {
                switch (t)
                {
                    case Word w: return w.Text;
                    case Punctuation p: return p.Text;
                    default: return t?.ToString() ?? "";
                }
            }));

            result = result
                .Replace(" ,", ",")
                .Replace(" .", ".")
                .Replace(" ?", "?")
                .Replace(" !", "!");
            return result.Trim();
        }
    }
}