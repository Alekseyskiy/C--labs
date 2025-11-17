using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPLabs.lab4;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        
        var processor = new TextProcessor();

        List<string> lines = new List<string>();

        Console.WriteLine("Введите текст построчно. Пустая строка — завершение ввода.\n");

        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                break;

            lines.Add(input);
        }

        var concordance = processor.BuildConcordance(lines);

        foreach (var pair in concordance.OrderBy(p => p.Key))
        {
            Console.WriteLine($"{pair.Key,-15} {pair.Value}");
        }
    }
}