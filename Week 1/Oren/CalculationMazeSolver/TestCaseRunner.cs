using System;
using System.IO;

namespace CalculationMazeSolver
{
    class TestCaseRunner
    {
        static void Main(string[] args)
        {
            RunTestCase("Input1.txt", "Output1.txt");
            RunTestCase("Input2.txt", "Output2.txt");
            Console.ReadLine();
        }

        static void RunTestCase(string inputFile, string outputFile)
        {
            string output = Solver.SolveFile(inputFile);
            string expected = File.ReadAllText(outputFile);

            if (expected.Trim() == output.Trim())
            {
                Console.WriteLine("Test passed.");
            }
            else
            {
                Console.WriteLine("Test failed.");
                Console.WriteLine("Expected: \r\n" + expected);
                Console.WriteLine("Actual: \r\n" + output);
            }
        }
    }
}
