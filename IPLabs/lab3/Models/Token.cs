using System.Xml.Serialization;

namespace IPLabs.lab3.Models
{
    [XmlInclude(typeof(Word))]
    public interface Token
    {
        string Text { get; set; }
    }
}