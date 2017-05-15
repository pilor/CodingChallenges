using System;
using System.IO;
using System.Text;

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
            Node solution = puzzle.Solve();
            string answer = solution.Location.TranslateLocation(puzzle).ToString();
            int nodes = 1;
            while (solution.Previous != null)
            {
                solution = solution.Previous;
                answer = solution.Location.TranslateLocation(puzzle) + " " + answer;
                nodes++;
            }
            Console.WriteLine(nodes);
            Console.WriteLine(answer);
            Console.WriteLine("press enter to exit");
            Console.ReadLine();
        }
    }
}