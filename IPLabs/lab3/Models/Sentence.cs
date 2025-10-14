using System.Collections.Generic;
using System.Linq;

namespace IPLabs.lab3.Models
{
    public class Sentence
    {
        public List<Token> Tokens { get; } = new();

        public int WordCount => Tokens.OfType<Word>().Count();
        
        public int DisplayLength => ToString().Length;

        public bool IsQuestion => ToString().TrimEnd().EndsWith("?");
        
        public override string ToString()
        {
            var result = string.Join(" ", Tokens.Select(t => t.Text));
            result = result.Replace(" ,", ",").Replace(" .", ".").Replace(" ?", "?");
            return result.Trim();
        }
    }
}