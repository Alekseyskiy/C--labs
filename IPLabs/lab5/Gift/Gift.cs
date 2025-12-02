using System.Collections.Generic;
using System.Linq;
using IPLabs.lab5.Sweets;

namespace IPLabs.lab5.Gift;

public class Gift
{
    private List<Sweet> sweets = new  List<Sweet>();

    public void AddSweet(Sweet sweet)
    {
        sweets.Add(sweet);
    }
    
    public double GetTotalWeight()
    {
        return sweets.Sum(s => s.Weight);
    }
    
    public void SortByWeight()
    {
        sweets = sweets.OrderBy(s => s.Weight).ToList();
    }
    
    
}