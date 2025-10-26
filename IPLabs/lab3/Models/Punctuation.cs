using System.Xml.Serialization;

namespace IPLabs.lab3.Models
{
    [XmlType("Punctuation")]
    public class Punctuation : Token
    {
        [XmlElement("Text")]
        public string Text { get; set; }
        
        public Punctuation() { }
        public Punctuation(string text) => Text = text;
        
        public override string ToString() => Text;
    }
}