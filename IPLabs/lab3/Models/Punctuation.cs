namespace IPLabs.lab3.Models
{
    public class Punctuation : Token
    {
        public string Text { get; set; }
        
        public Punctuation() { }
        public Punctuation(string text) => Text = text;
        
        public override string ToString() => Text;
    }
}