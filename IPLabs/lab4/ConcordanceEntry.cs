using System.Collections.Generic;

namespace IPLabs.lab4;

public class ConcordanceEntry
{
    public int Count { get; set; }
    public SortedSet<int> Lines { get; set; } = new SortedSet<int>();

    public override string ToString()
    {
        return $"{Count}: {string.Join(" ", Lines)}";
    }
}