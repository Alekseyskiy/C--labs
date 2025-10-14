using System;
using IPLabs.lab3.Models;
using IPLabs.lab3.Services;

namespace IPLabs.lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            string input = "Привет, как дела? Это тест предложение. Как слышно. Слово из пяти букв.";

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
            
            Console.WriteLine("3. Удалить слова заданной длины (4) начинающиеся с согласной:");
            text.RemoveWordsStartingWithConsonant(4);
            Console.WriteLine(text);
            Console.WriteLine();
            
            Console.WriteLine("4. Заменить слова заданной длины (5) в предложении:");
            text.ReplaceWordsInSentence(3, 5, "замена");
            Console.WriteLine(text);
            Console.WriteLine();
        }
    }
}