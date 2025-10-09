using IPLabs.lab3.Models;

namespace IPLabs.lab3
{
    public class Word : Token
    {
        public string Text { get; set; }
        
        public Word(string text) => Text = text;
        
        public override string ToString() => Text;
    }
}