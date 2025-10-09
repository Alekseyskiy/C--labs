using System.Collections.Generic;

namespace IPLabs.lab3.Models
{
    public class Sentence
    {
        public List<Token> Tokens { get; set; }
        
        public override string ToString() => Tokens.ToString();
    }
}