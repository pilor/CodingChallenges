// ------------------------- Week1_Maze ------------------------------------
// Karen Schoen
// Creation date: 4/5/2017
// Date of last modification: 
// -------------------------------------------------------------------------
// The stated problem is to solve a calculation maze, as explained in detail 
// here (http://www.mazelog.com/show?15).
//
// Given an input maze, and the target number required to exit, determine
// the path through the maze starting at the top left and ending at the
// bottom right, in the shortest number of steps.

// Input format:
// * The first line of input is an integer T, the target number to reach.
// * The next N lines are individual rows of the maze, representing cells 
// separated by spaces.
// * The first cell(top left) is an integer.Subsequent cells are a 
// mathematical operator (+, -, *) followed by an integer.
//
// Output format:
// * The first line of the output is the length in steps of the optimal 
// solution.The starting cell counts as the first step.
// * The next line of the output is the solution, formatted as described on
// the link above.
//     * Each cell of the grid can be numbered, starting with 1 in the top 
// left, left to right then top to bottom.
//     * The solution is a space-separated list of numbered cells visited. 
// The first number is 1, and the last is the number in the bottom right.
// * (Optional) If there are multiple valid solutions, they are listed on 
// subsequent lines, sorted alphabetically.
//
// Valid input and output test cases are listed under the "Tests" directory.
// -------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Week1_Maze
{
    public class Maze
    {
        private double firstLine;
        private int desiredEndResultNum;
        private int amountOfNumsInPath;
        private string path;
        private string[] lines;
        private string[,] matrix;
        private int mazeSize;

        // later, save all correct paths, compare sizes and print optimal paths
        int shortestListSize = 0;
        List<List<int>> possiblePaths = new List<List<int>>();

        public Maze() { }

        public Maze(string textFileName)
        {
            // Read each line of the file into a string array. Each
            // element of the array is one line of the file.
            lines = System.IO.File.ReadAllLines(textFileName);

            // A maze must contain target number and at least 1 number in the maze
            if (lines.Length >= 2)
            {
                // gives us the number of text lines readed
                mazeSize = lines.Length;
                matrix = new string[mazeSize - 1, mazeSize - 1];

                try
                {
                    firstLine = Convert.ToDouble(lines[0]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Target number required to exit must be a sequence of digits without comas.");
                }

                if ((firstLine % 1 != 0))
                {
                    Console.Out.WriteLine("Target number required to exit can't be decimal");
                }

                // Even if 1st num is a decimal, it tries to solve the
                // problem by converting it to integer. 
                //int desiredEndResultNum = 
                desiredEndResultNum = Convert.ToInt32(firstLine);

                CreateMatrix(lines);
            }
            else
            {
                Console.WriteLine("Maze must contain target number and it must be made of at least 1 number");
            }
        }

        public int GetDesiredEndResultNum()
        {
            return desiredEndResultNum;
        }

        public int GetAmountOfNumsInPath()
        {
            return amountOfNumsInPath;
        }

        public string GetPath()
        {
            return path;
        }

        public string GetLines(int num)
        {
            return lines[num];
        }

        public int GetMazeSize()
        {
            return mazeSize;
        }

        public string GetMatrix(int row, int column)
        {
            return matrix[row, column];
        }

        private void CreateMatrix(string[] lines)
        {
            for (int rowNum = 1; rowNum < mazeSize; rowNum++)
            {
                string[] integerStrings = lines[rowNum].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for (int columnNum = 0; columnNum <= mazeSize-2; columnNum++)
                {
                    matrix[rowNum-1, columnNum] = integerStrings[columnNum];
                }
            }
        }

        // save path in list, display shortest list that reaches bottom left and == target #
        // constantly check if == target and if it is bottom left. 

        // I'm assuming that the target number is never equal to the top left
        // number of the maze when the maze is 2x2 or bigger.
        public void SolveMaze()
        {
            if (matrix != null)
            {
                int current = Convert.ToInt32(matrix[0, 0]);
                int currentY = 0;
                int currentX = 0;

                // If maze is 1x1
                if (current == desiredEndResultNum)
                {
                    amountOfNumsInPath = 1;
                    path = "1";
                }
                else
                {
                    List<int> yxPath = new List<int>(); // saves path as y*10 and x*1
                    ReachTargetNumber(currentY, currentX, current, yxPath);
                }
            }
        }


        public void ReachTargetNumber(int currentY, int currentX, int current, List<int> yxPath)
        {
            // Checks if we have reach the bottom right of the maze
            if (currentY == mazeSize - 2 && currentX == mazeSize - 2)
            {
                if (current == desiredEndResultNum)
                {
                    possiblePaths.Add(yxPath);
                    return;
                }
                // Next if statements check if we are at the edge of the maze or inside 
                else
                {
                    // gets next right number -->
                    if (currentX <= mazeSize - 3)
                    {
                        currentX++;
                        string integerString = matrix[currentY, currentX];
                        char nextOperator = integerString[0];
                        int nextNum = Convert.ToInt32(integerString.Substring(1));

                        // Performs the operation and updates the position
                        current = Calculator(current, nextOperator, nextNum);

                        // Calls the function to see if we have reach our goal
                        ReachTargetNumber(currentY, currentX, current, yxPath);
                    }

                    // gets next down number
                    if (currentY <= mazeSize - 3)
                    {
                        currentY++;
                        string integerString = matrix[currentY, currentX];
                        char nextOperator = integerString[0];
                        int nextNum = Convert.ToInt32(integerString.Substring(1));

                        // Performs the operation and updates the position
                        current = Calculator(current, nextOperator, nextNum);

                        // Calls the function to see if we have reach our goal
                        ReachTargetNumber(currentY, currentX, current, yxPath);
                    }

                    // gets next left number <--
                    // Once it has reach the bottom right, it won't keep going back into the maze
                    if (currentX >= 0 && currentX <= mazeSize - 3 && currentY <= mazeSize - 3)
                    {
                        currentX--;
                        string integerString = matrix[currentY, currentX];
                        char nextOperator = integerString[0];
                        int nextNum = Convert.ToInt32(integerString.Substring(1));

                        // Performs the operation and updates the position
                        current = Calculator(current, nextOperator, nextNum);

                        // Calls the function to see if we have reach our goal
                        ReachTargetNumber(currentY, currentX, current, yxPath);
                    }

                    // gets next up number
                    // Once it has reach the bottom right, it won't keep going back into the maze
                    if (currentY >= 0 && currentX <= mazeSize - 3 && currentY <= mazeSize - 3)
                    {
                        currentY--;
                        string integerString = matrix[currentY, currentX];
                        char nextOperator = integerString[0];
                        int nextNum = Convert.ToInt32(integerString.Substring(1));

                        // Performs the operation and updates the position
                        current = Calculator(current, nextOperator, nextNum);

                        // Calls the function to see if we have reach our goal
                        ReachTargetNumber(currentY, currentX, current, yxPath);
                    }
                }
            }
        }

        public int Calculator(int current, char nextRightOperator, int nextRightNum)
        {
            if (nextRightOperator == '+')
            {
                return current + nextRightNum;
            }
            else if (nextRightOperator == '-')
            {
                return current - nextRightNum;
            }
            else if (nextRightOperator == '*')
            {
                return current * nextRightNum;
            }
            else
            {
                Console.WriteLine("Operators can only be +, -, and *. Your maze contains the simbol "
                    + nextRightOperator + " which will be taken as an addition.");
                return current + nextRightNum;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\Visual Studio 2015\Projects\Week1_Maze\Week1_Maze\Input0.txt");

        }
    }
}
