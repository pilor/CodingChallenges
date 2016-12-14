using System;
using System.IO;

namespace CalcMaze
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var prog = new Program();
            var path = @"D:\Git\CodingChallenges\Week 1\Tests\Input2.txt";
            if (!File.Exists(path))
            {
                path = @"C:\Git\CodingChallenges\Week 1\Tests\Input2.txt";
            }
            prog.Run(path);
        }

        private void Run(string inputPath)
        {
            var allText = File.ReadAllText(inputPath);
            var puzzle = InputParser.Parse(allText);
            var solution = puzzle.Solve();
            Console.WriteLine(solution.Split(' ').Length);
            Console.WriteLine(solution);
            Console.WriteLine("press enter to exit");
            Console.ReadLine();
        }
    }
}