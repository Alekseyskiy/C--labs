using System.Xml.Serialization;

namespace IPLabs.lab3.Models
{
    [XmlInclude(typeof(Word))]
    [XmlInclude(typeof(Punctuation))]
    public interface Token
    {
        string Text { get; set; }
    }
}