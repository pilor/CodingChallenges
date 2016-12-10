namespace CalcMaze
{
    using System.IO;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var prog = new Program();
            prog.Run(@"D:\Git\CodingChallenges\Week 1\Tests\Input1.txt");
        }

        private void Run(string inputPath)
        {
            string allText = File.ReadAllText(inputPath);
            var puzzle = InputParser.Parse(allText);
        }
    }
}