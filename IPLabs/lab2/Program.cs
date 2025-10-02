using System;
using System.Globalization;
using System.IO;
using IPLabs.lab2.model;

namespace IPLabs.lab2
{
    public class Program
    {
        static void Main()
        {
            string currentDir = @"C:\Users\ASUS\RiderProjects\IPLabs\IPLabs\lab2\files";

            Console.WriteLine($"Working directory: {currentDir}");

            var inputFiles = Directory.GetFiles(currentDir, "*.ChaseData.txt");

            if (inputFiles.Length == 0)
            {
                Console.WriteLine("No input files (*.ChaseData.txt) found.");
                return;
            }

            foreach (var inputFile in inputFiles)
            {
                try
                {
                    Console.WriteLine($"\nProcessing {Path.GetFileName(inputFile)}...");

                    var allLines = File.ReadAllLines(inputFile);

                    int lineIndex = 0;
                    while (lineIndex < allLines.Length && string.IsNullOrWhiteSpace(allLines[lineIndex]))
                        lineIndex++;

                    if (lineIndex >= allLines.Length)
                        throw new Exception("File contains no board size.");

                    if (!int.TryParse(allLines[lineIndex].Trim(),
                            NumberStyles.Integer,
                            CultureInfo.InvariantCulture,
                            out int boardSize))
                        throw new Exception("Invalid board size in input file.");

                    var game = new Game(boardSize);

                    for (int i = lineIndex + 1; i < allLines.Length; i++)
                    {
                        string cmd = allLines[i];
                        game.ProcessCommandLine(cmd);

                        if (game.IsOver)
                            break;
                    }

                    string dir = Path.GetDirectoryName(inputFile);
                    if (dir == null)
                        dir = Directory.GetCurrentDirectory();

                    string outputFile = Path.Combine(
                        dir,
                        Path.GetFileNameWithoutExtension(inputFile).Replace("ChaseData", "PursuitLog") + ".txt"
                    );

                    var finalLines = game.GetFinalLines();
                    File.WriteAllLines(outputFile, finalLines);

                    Console.WriteLine($"Result written to {Path.GetFileName(outputFile)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing {Path.GetFileName(inputFile)}: {ex.Message}");
                }
            }

            Console.WriteLine("\nAll files processed.");
        }
    }
}