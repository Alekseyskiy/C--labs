using System;
using System.Collections.Generic;
using System.Linq;
using IPLabs.lab5.Sweets;

namespace IPLabs.lab5.Gifts;

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
    
    public Sweet FindSweetBySugar(double min, double max)
    {
        return sweets.FirstOrDefault(s => s.SugarContent >= min && s.SugarContent <= max);
    }
    
    public void ShowContents()
    {
        foreach (var sweet in sweets)
        {
            Console.WriteLine(sweet);
        }
        Console.WriteLine($"Total weight: {GetTotalWeight()}g");
    }
    
    public void RemoveSweet(int index)
    {
        if (index < 0 || index >= sweets.Count)
        {
            Console.WriteLine("Ошибка: индекс вне диапазона!");
            return;
        }

        sweets.RemoveAt(index);
        Console.WriteLine("Сладость удалена.");
    }
}