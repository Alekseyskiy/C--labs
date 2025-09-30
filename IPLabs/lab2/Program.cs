using System;
using IPLabs.lab2.model;

namespace IPLabs.lab2
{
    public class Program
    {
        static void Main()
        {
            var game = new Game(20);

            string[] commands = new[]
            {
                "M 6",
                "C 17",
                "P",
                "C -15",
                "M -7",
                "P",
                "C 3",
                "C -5",
                "C 10",
                "P"
            };

            foreach (var cmd in commands)
            {
                game.ProcessCommandLine(cmd);
                if (game.IsOver) break; 
            }

            Console.WriteLine("Print rows:");
            foreach (var r in game.PrintLines)
                Console.WriteLine(r);

            Console.WriteLine("\nFinal log:");
            foreach (var line in game.GetFinalLines())
                Console.WriteLine(line);
        }
    }
}