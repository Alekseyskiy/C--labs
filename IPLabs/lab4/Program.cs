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

        /*
            Привет, как дела в прекрасном Петербурге?
            Погода сегодня просто замечательная, светит яркое солнце.
            Прогуливаясь по набережной Невы, я встретил старого друга.
            Мы разговорились о жизни, работе и планах на будущее.
            Петербург всегда поражает своей красотой и величием.

            */

        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                break;

            lines.Add(input);
        }

        var (chars, concordance) = processor.BuildConcordance(lines);

        Console.WriteLine("\n--- КОНКОРДАНС ---\n");

        var groupedConcordance = concordance
            .GroupBy(p => p.Key[0].ToString())
            .OrderBy(g => g.Key);

        foreach (var group in groupedConcordance)
        {
            string letter = group.Key;

            if (chars.ContainsKey(letter))
            {
                var charInfo = chars[letter];
                Console.WriteLine(
                    $"Буква '{letter}' (встречается {charInfo.Count} раз в строках: {charInfo}):");
            }
            else
            {
                Console.WriteLine($"Буква '{letter}':");
            }

            foreach (var pair in group.OrderBy(p => p.Key))
            {
                Console.WriteLine($"{pair.Key,-15} {pair.Value}");
            }

            int totalWordOccurrences = group.Sum(p => p.Value.Count);
            Console.WriteLine($"Всего вхождений слов на '{letter}': {totalWordOccurrences}\n");
        }
    }
}