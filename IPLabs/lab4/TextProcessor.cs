using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IPLabs.lab4;

public class TextProcessor
{
    public (Dictionary<string, CountWords>, Dictionary<string, ConcordanceEntry>) BuildConcordance(List<string> lines)
    {
        var concordance = new Dictionary<string, ConcordanceEntry>();
        var words = new Dictionary<string, CountWords>();
        Regex regex = new Regex(@"[A-Za-zА-Яа-яЁё\-]+", RegexOptions.IgnoreCase);

        for (int i = 0; i < lines.Count; i++)
        {
            int lineNumber = i + 1;

            foreach (Match match in regex.Matches(lines[i]))
            {
                string word = match.Value.ToLower();
                
                string chars = word[0].ToString();

                if (!words.ContainsKey(chars))
                {
                    words[chars] = new CountWords();
                }
                
                words[chars].Count++;
                words[chars].Lines.Add(lineNumber);

                if (!concordance.ContainsKey(word))
                {
                    concordance[word] = new ConcordanceEntry();
                }

                concordance[word].Count++;
                concordance[word].Lines.Add(lineNumber);
            }
        }
        
        foreach (var entry in words.Values)
        {
            entry.Count += 1;
        }
        
        foreach (var entry in concordance.Values)
        {
            entry.Count += 1;
        }

        return (words, concordance);
    }
}