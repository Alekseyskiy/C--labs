using System.Xml.Serialization;
using IPLabs.lab3.Models;

namespace IPLabs.lab3
{
    [XmlType("Word")]
    public class Word : Token
    {
        [XmlElement("Text")]
        public string Text { get; set; }
        
        public Word() { }
        
        public Word(string text) => Text = text;
        
        public override string ToString() => Text;
    }
}