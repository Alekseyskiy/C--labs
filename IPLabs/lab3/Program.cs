using System;
using IPLabs.lab3.Models;
using IPLabs.lab3.Services;

namespace IPLabs.lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = "Привет, как дела? Это тестовое предложение. Как слышно.";

            TextParser parser = new TextParser();
            Text text = parser.Parse(input);
            
            Console.WriteLine("1. Предложения гле вопросительное с N словами (пример N = 3):");
            foreach (var sentence in text.GetQuestionSentencesWithWordCount(3)) 
                Console.WriteLine(sentence);
            Console.WriteLine();
            
            Console.WriteLine("2. Предложения по возрастагию длины:");
            foreach (var sentence in text.GetSentencesOrderedByLength())
                Console.WriteLine(sentence);
            Console.WriteLine();
        }
    }
}