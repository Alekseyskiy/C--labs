using System.Collections.Generic;

namespace IPLabs.lab3.Models
{
    public class Sentence
    {
        public List<Token> Tokens { get; set; }
        
        public int WordCount { get; set; }
        
        public int DisplayLength => ToString().Length;

        public bool IsQuestion => ToString().TrimEnd().EndsWith("?");
        
        public override string ToString() => Tokens.ToString();
    }
}