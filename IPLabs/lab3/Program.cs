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
    //      static void Main(string[] args)
    //      {
    //          Console.OutputEncoding = Encoding.UTF8;
    //          Console.InputEncoding = Encoding.UTF8;
    //     
    //          string inputPath = @"C:\Users\ASUS\RiderProjects\IPLabs\IPLabs\lab3\files\input.txt";
    //          string outputPath = @"C:\Users\ASUS\RiderProjects\IPLabs\IPLabs\lab3\files\output.txt";
    //
    //          if (!File.Exists(inputPath))
    //          {
    //              Console.WriteLine("Input file not found");
    //          }
    //          
    //          if (!File.Exists(outputPath))
    //          {
    //              Console.WriteLine("Output file not found");
    //          }
    //          
    //          string input = File.ReadAllText(inputPath);
    //     
    //          TextParser parser = new TextParser();
    //          Text text = parser.Parse(input);
    //          
    //          StringBuilder sb = new StringBuilder();
    //
    //          sb.AppendLine("Исходный текст:");
    //          sb.AppendLine(input);
    //          sb.AppendLine();
    //
    //          sb.AppendLine("1. Предложения по возрастанию кол-ва слов в предложении");
    //          foreach (Sentence sentence in text.GetSentencesOrderedByWordCount())
    //              sb.AppendLine(sentence.ToString());
    //          sb.AppendLine();
    //          
    //          sb.AppendLine("2. Предложения по возрастагию длины:");
    //          foreach (var sentence in text.GetSentencesOrderedByLength())
    //              sb.AppendLine(sentence.ToString());
    //          sb.AppendLine();
    //          
    //          sb.AppendLine("3. Вопросительные предложения где слова с длиной N (пример N = 3):");
    //          foreach (var sentence in text.GetUniqueWordsInQuestionsByLength(3)) 
    //              sb.AppendLine(sentence);
    //          sb.AppendLine();
    //          
    //          sb.AppendLine("4. Удалить слова заданной длины (5) начинающиеся с согласной:");
    //          text.RemoveWordsStartingWithConsonant(5);
    //          sb.AppendLine(text.ToString());
    //          sb.AppendLine();
    //          
    //          sb.AppendLine("5. Заменить слова заданной длины (5) в предложении:");
    //          text.ReplaceWordsInSentence(0, 3, "замена");
    //          sb.AppendLine(text.ToString());
    //          sb.AppendLine();
    //
    //          sb.AppendLine("6. Текст без стоп-слов:");
    //          text.RemoveStopWords();
    //          sb.AppendLine(text.ToString());
    //          sb.AppendLine();
    //
    //          sb.AppendLine("7. XML-представление");
    //          var serializer = new XmlSerializer(typeof(Text));
    //          using (var writer = new StringWriter())
    //          {
    //              serializer.Serialize(writer, text);
    //              sb.AppendLine(writer.ToString());   
    //          }
    //          
    //          File.WriteAllText(outputPath, sb.ToString(), Encoding.UTF8);
    //          
    //          Console.WriteLine("Всё записано в output.txt");
    //     }
     }
}