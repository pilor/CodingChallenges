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
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
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
        private int shortestListSize = 0;
        private List<Pointer[]> possiblePaths = new List<Pointer[]>();
        private bool continueRecursion = true;
        private bool wasGoalReached = false;
        private int timesReachBottomRight = 0;
        private Queue<Pointer> myQueue = new Queue<Pointer>();
        private Pointer[] arrayOfParentPointers;
        private List<Pointer> yxPath = new List<Pointer>();
        private List<Pointer> listOfParentPointers = new List<Pointer>();

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

        public List<Pointer[]> GetPossiblePaths()
        {
            return possiblePaths;
        }

        // It creates a matrix with this coordinates
        // Y,X
        // 0,0 | 0,1 | 0,2 ...
        // 1,0 | 1,1 | 1,2 ...
        // 2,0 | 2,1 | 2,2 ...
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
                    Pointer currentPointer = new Pointer(currentY, currentX, current);
                    AddToQueue(currentPointer);

                    // It tries to find a path right and down
                    //ReachTargetNumber(currentY, currentX +1, current, yxPath);

                    //Pointer[] addableList = new Pointer[yxPath.Count];
                    //if (yxPath.Count > 0)
                    //{
                    //    addableList = yxPath.ToArray();
                    //    possiblePaths.Add(addableList);
                   //     yxPath.Clear();
                    //}
                    //timesReachBottomRight = 0;
                    //continueRecursion = true;

                    //ReachTargetNumber(currentY + 1, currentX, current, yxPath);
                    //if (yxPath.Count > 0)
                    //{
                    //    addableList = yxPath.ToArray();
                    //    possiblePaths.Add(addableList);
                    //    yxPath.Clear();
                    //}
                }

                TranslatePath();
            }
        }

        public void AddToQueue(Pointer parentPointer)
        {
            Pointer currentPointerRight = new Pointer(parentPointer.Y, parentPointer.getX() + 1, parentPointer.getCurrent());
            currentPointerRight.setParentPointer(parentPointer);
            myQueue.Enqueue(currentPointerRight);

            Pointer currentPointerLeft = new Pointer(parentPointer.Y, parentPointer.getX() - 1, parentPointer.getCurrent());
            currentPointerLeft.setParentPointer(parentPointer);
            myQueue.Enqueue(currentPointerLeft);

            Pointer currentPointerDown = new Pointer(parentPointer.Y + 1, parentPointer.getX(), parentPointer.getCurrent());
            currentPointerDown.setParentPointer(parentPointer);
            myQueue.Enqueue(currentPointerDown);

            Pointer currentPointerUp = new Pointer(parentPointer.Y - 1, parentPointer.getX(), parentPointer.getCurrent());
            currentPointerUp.setParentPointer(parentPointer);
            myQueue.Enqueue(currentPointerUp);

            while (wasGoalReached == false && myQueue.Count > 0)
            {
                WorkQueue();
            }
        }

        public void WorkQueue()
        {
            Pointer currentPointer = new Pointer(myQueue.Dequeue());
            if (currentPointer.getX() <= mazeSize - 2 && currentPointer.Y <= mazeSize - 2 &&
                 currentPointer.getX() >= 0 && currentPointer.Y >= 0 &&
                !(currentPointer.Y == 0 && currentPointer.getX() == 0))
            {
                string integerString = matrix[currentPointer.Y, currentPointer.getX()];
                char nextOperator = integerString[0];
                int nextNum = Convert.ToInt32(integerString.Substring(1));

                // Performs the operation and updates the position
                currentPointer.setCurrent(Calculator(currentPointer.getCurrent(), nextOperator, nextNum));

                // Checks if we have reach the bottom right of the maze & have reach our goal
                if (currentPointer.Y == mazeSize - 2 && currentPointer.getX() == mazeSize - 2)
                    //&& currentPointer.getCurrent() == desiredEndResultNum)
                {
                    if (currentPointer.getCurrent() == desiredEndResultNum)
                    {
                        wasGoalReached = true;
                        SavePath(currentPointer);
                    }
                }
                if (wasGoalReached == false)
                {
                    AddToQueue(currentPointer);
                }
            }
        }

        public void SavePath(Pointer currentPointer)
        {
            yxPath.Add(currentPointer);
            while (currentPointer.GetParentPointer() != null)
            {
                yxPath.Add((currentPointer.GetParentPointer()));
                currentPointer = currentPointer.GetParentPointer();
            }
        }

        public void ReachTargetNumber(int currentY, int currentX, int current, List<Pointer> yxPath)
        {
            // Next if statements check if we are at the edge of the maze or inside 
            if (currentX <= mazeSize - 2 && currentY <= mazeSize - 2 && currentX >= 0 && currentY >= 0 &&
                !(currentY == 0 && currentX == 0))
            {
                string integerString = matrix[currentY, currentX];
                char nextOperator = integerString[0];
                int nextNum = Convert.ToInt32(integerString.Substring(1));

                // Performs the operation and updates the position
                int potentialCurrent = Calculator(current, nextOperator, nextNum);

                // Checks if we have reach the bottom right of the maze & have reach our goal
                if (currentY == mazeSize - 2 && currentX == mazeSize - 2)
                {
                    timesReachBottomRight++;
                    if (timesReachBottomRight > mazeSize) //Math.Pow(mazeSize, 5))
                    {
                        continueRecursion = false;
                    }
                    if (potentialCurrent == desiredEndResultNum)
                    {
                        wasGoalReached = true;
                        continueRecursion = false;
                    }
                }

                // it tries to find a path right, down, left, and up.
                if (continueRecursion == true)
                {
                    ReachTargetNumber(currentY, currentX + 1, potentialCurrent, yxPath);
                }
                if (continueRecursion == true)
                {
                    ReachTargetNumber(currentY + 1, currentX, potentialCurrent, yxPath);
                }
                if (continueRecursion == true)
                {
                    ReachTargetNumber(currentY, currentX - 1, potentialCurrent, yxPath);
                }
                if (continueRecursion == true)
                {
                    ReachTargetNumber(currentY - 1, currentX, potentialCurrent, yxPath);
                }
                if (wasGoalReached == true)
                {
                    yxPath.Add(new Pointer(currentY, currentX));
                }
                if (currentY == mazeSize - 2 && currentX == mazeSize - 2)
                {
                    timesReachBottomRight--;
                }

                // zero intead of one, because in this same loop I just added to the variable
                if (timesReachBottomRight < 1)
                {
                    continueRecursion = true;
                }
                else
                {
                    potentialCurrent = current;
                }
            }
        }
        // After I found the first path, then just let the other 3 paralel recursive methods end
        // and then leave, since if they keep going they would only give me longer paths than what
        // I already have. 

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

        public void TranslatePath()
        {
            yxPath.Reverse();
            path += yxPath.Count + "\n";
            path += "1";
            for (int arrayIndex = 1; arrayIndex < yxPath.Count; arrayIndex++)
            {
                if (yxPath[arrayIndex].Y == 0)
                {
                    path += " " + (yxPath[arrayIndex].getX() + 1);
                }
                else
                {
                    for (int y = 1; y <= mazeSize - 2; y++)
                    {
                        if (yxPath[arrayIndex].Y == y)
                        {
                            path += " " + (mazeSize * y - (y - 1) +
                                           yxPath[arrayIndex].getX());
                            y = mazeSize; //to break loop once the right value of y has been found
                        }
                    }
                }
            }
        }

        public void TranslatePossiblePaths()
        {
            if (possiblePaths.Count != 0)
            {
                // finds the lenght of the shortest possible path
                int shortestPathLenght = possiblePaths[0].Length;
                for (int i = 1; i < possiblePaths.Count; i++)
                {
                    if (possiblePaths[i].Length < shortestPathLenght)
                    {
                        shortestPathLenght = possiblePaths[i].Length;
                    }
                }

                // saves all correct paths of the shortest lenght
                List<Pointer[]> listOfShortPaths = new List<Pointer[]>();
                for (int i = 0; i < possiblePaths.Count; i++)
                {
                    if (possiblePaths[i].Length == shortestPathLenght)
                    {
                        listOfShortPaths.Add(possiblePaths[i]);
                    }
                }

                // saves path lenght
                amountOfNumsInPath = shortestPathLenght + 1;

                // translate path pointers
                for (int pathNumber = 0; pathNumber < listOfShortPaths.Count; pathNumber++)
                {
                    path += "1";
                    //for (int arrayIndex = 0; arrayIndex < listOfShortPaths[pathNumber].Length; arrayIndex++)
                    for(int arrayIndex = listOfShortPaths[pathNumber].Length -1; arrayIndex >= 0; arrayIndex--)
                    {
                        if (listOfShortPaths[pathNumber][arrayIndex].Y == 0)
                        {
                            path += " " + listOfShortPaths[pathNumber][arrayIndex].getX() + 1;
                        }
                        else
                        {
                            for (int y = 1; y <= mazeSize - 2; y++)
                            {
                                if (listOfShortPaths[pathNumber][arrayIndex].Y == y)
                                {
                                    path += " " + ((mazeSize * y - (y - 1)) +
                                            listOfShortPaths[pathNumber][arrayIndex].getX());
                                }
                            }
                        }
                    }

                    if (pathNumber != listOfShortPaths.Count - 1)
                    {
                        path += "\n";
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Maze myMaze1 = new Maze(@"C:\Users\ana_k\Documents\CodingChallenges\Week 1\Karen\Week1_Maze\Week1_Maze\Input0.txt");

        }
    }
}
