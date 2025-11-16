using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IPLabs.lab4;

public class TextProcessor
{
    public Dictionary<string, ConcordanceEntry> BuildConcordance(List<string> lines)
    {
        var concordance = new Dictionary<string, ConcordanceEntry>();
        Regex regex = new Regex(@"[A-Za-zА-Яа-яЁё\-]+", RegexOptions.IgnoreCase);

        for (int i = 0; i < lines.Count; i++)
        {
            int lineNumber = i + 1;

            foreach (Match match in regex.Matches(lines[i]))
            {
                string word = match.Value.ToLower();

                if (!concordance.ContainsKey(word))
                {
                    concordance[word] = new ConcordanceEntry();
                }

                concordance[word].Count++;
                concordance[word].Lines.Add(lineNumber);
            }
        }

        return concordance;
    }
}