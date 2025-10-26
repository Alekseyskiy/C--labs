using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using IPLabs.lab3.Models;
using IPLabs.lab3.Services;

namespace IPLabs.lab3
{
    public class Program
    {
         static void Main(string[] args)
         {
             Console.OutputEncoding = Encoding.UTF8;
             Console.InputEncoding = Encoding.UTF8;
        
             string inputPath = @"C:\Users\ASUS\RiderProjects\IPLabs\IPLabs\lab3\files\input.txt";
             string outputPath = @"C:\Users\ASUS\RiderProjects\IPLabs\IPLabs\lab3\files\output.txt";

             if (!File.Exists(inputPath))
             {
                 Console.WriteLine("Input file not found");
             }
             
             string input = File.ReadAllText(inputPath);
        
             TextParser parser = new TextParser();
             Text text = parser.Parse(input);
             
             StringBuilder sb = new StringBuilder();

             sb.AppendLine("Исходный текст:");
             sb.AppendLine(input);
             sb.AppendLine();
             
             Console.WriteLine("1. Предложения гле вопросительное с N словами (пример N = 3):");
             foreach (var sentence in text.GetQuestionSentencesWithWordCount(3)) 
                 sb.AppendLine(sentence.ToString());
             sb.AppendLine();
             
             Console.WriteLine("2. Предложения по возрастагию длины:");
             foreach (var sentence in text.GetSentencesOrderedByLength())
                 sb.AppendLine(sentence.ToString());
             sb.AppendLine();
             
             Console.WriteLine("3. Удалить слова заданной длины (4) начинающиеся с согласной:");
             text.RemoveWordsStartingWithConsonant(4);
             sb.AppendLine(text.ToString());
             sb.AppendLine();
             
             Console.WriteLine("4. Заменить слова заданной длины (5) в предложении:");
             text.ReplaceWordsInSentence(3, 5, "замена");
             sb.AppendLine(text.ToString());
             sb.AppendLine();

             sb.AppendLine("5. XML-представление");
             var serializer = new XmlSerializer(typeof(Text));
             using (var writer = new StringWriter())
             {
                 serializer.Serialize(writer, text);
                 sb.AppendLine(writer.ToString());   
             }
             
             File.WriteAllText(outputPath, sb.ToString(), Encoding.UTF8);
        }
    }
}