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
    }
}