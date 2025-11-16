using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IPLabs.lab4;

public class TextProcessor
{
    public Dictionary<string, ConcordanceEntry> BuildConcordance(List<string> lines)
    {
        var concordance = new Dictionary<string, ConcordanceEntry>();
        Regex regex = new Regex(@"[A-Za-zА-Яа-яЁё]+", RegexOptions.IgnoreCase);
        

        return concordance;
    }
}