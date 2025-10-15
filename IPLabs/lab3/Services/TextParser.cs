using System.Text.RegularExpressions;
using IPLabs.lab3.Models;

namespace IPLabs.lab3.Services
{
    public class TextParser
    {
        public Text Parse(string input)
        {
            var text = new Text();

            string[] rawSentences = Regex.Split(input, @"(?<=[.!?])\s+");

            foreach (string raw in rawSentences)
            {
                var sentence = new Sentence();
                var tokens = Regex.Matches(raw, @"[\w-]+|[^\w\s]+");

                foreach (Match m in tokens)
                {
                    if (Regex.IsMatch(m.Value, @"^\w+$"))
                        sentence.Tokens.Add(new Word(m.Value));
                    else
                        sentence.Tokens.Add(new Punctuation(m.Value));
                }

                text.Sentences.Add(sentence);
            }

            return text;
        }
    }
}