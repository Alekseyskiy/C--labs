using System.Collections.Generic;
using System.Linq;

namespace IPLabs.lab3.Models
{
    public class Text
    {
        public List<Sentence> Sentences { get; } = new();

        public IEnumerable<Sentence> GetQuestionSentencesWithWordCount(int count) =>
            Sentences.Where(s => s.IsQuestion && s.WordCount == count);

        public IEnumerable<Sentence> GetSentencesOrderedByLength() =>
            Sentences.OrderBy(s => s.DisplayLength);
        
        public void RemoveWordsStartingWithConsonant(int length)
        {
            string consonants = "бвгджзйклмнпрстфхцчшщ";
            foreach (var sentence in Sentences)
            {
                sentence.Tokens.RemoveAll(t =>
                    t is Word w &&
                    w.Text.Length == length &&
                    consonants.Contains(char.ToLower(w.Text[0])));
            }
        }
        
        public void ReplaceWordsInSentence(int index, int length, string replacement)
        {
            if (index < 0 || index >= Sentences.Count) return;

            var sentence = Sentences[index];
            for (int i = 0; i < sentence.Tokens.Count; i++)
            {
                if (sentence.Tokens[i] is Word w && w.Text.Trim().Length == length)
                    sentence.Tokens[i] = new Word(replacement);
            }
        }
        
        public override string ToString() => string.Join(" ", Sentences.Select(s => s.ToString()));
    }
}