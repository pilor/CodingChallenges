using System;

namespace CalcMaze
{
    using System.IO;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var prog = new Program();
            string path = @"D:\Git\CodingChallenges\Week 1\Tests\Input0.txt";
            if (!File.Exists(path))
            {
                path = @"C:\Git\CodingChallenges\Week 1\Tests\Input0.txt";
            }
            prog.Run(path);
        }

        private void Run(string inputPath)
        {
            string allText = File.ReadAllText(inputPath);
            var puzzle = InputParser.Parse(allText);
            Console.WriteLine(puzzle.Solve());
            Console.WriteLine("press enter to exit");
            Console.ReadLine();
        }
    }
}