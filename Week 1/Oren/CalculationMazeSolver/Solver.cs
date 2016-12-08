using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculationMazeSolver
{
    class Solver
    {
        //static string[] InputLines =
        //{
        //    "2 +2 -1",
        //    "-1 *3 +1",
        //    "+1 +4 +1"
        //};

        //const int InputTarget = 6;

        static string[] InputLines =
        {
            "0 +1 *3 +2 -2",
            "+1 *4 *2 -2 -2",
            "*2 +2 -2 +2 *2",
            "+2 -2 *2 *4 +1",
            "+0 +2 *3 +3 +1"
        };

        const int InputTarget = 21;

        const int MaxSteps = 30;

        static void Main(string[] args)
        {
            string[][] maze = InputLines.Select(l => l.Split(' ')).ToArray();

            List<Path> solutions = Solve(maze, InputTarget);

            if (solutions != null)
            {
                Console.WriteLine(solutions[0].Points.Count);
                //Console.WriteLine(String.Join(";", solution.Points.Select(p => p.ToString())));
                //Console.WriteLine(String.Concat(solution.Points.Select(p => maze[p.Y][p.X])) + "=" + solution.Value);

                // Format used by the site
                foreach (Path solution in solutions)
                {
                    Console.WriteLine(String.Join(" ", solution.Points.Select(p => p.X + 1 + (maze.Length * p.Y))));
                }
            }
            else
            {
                Console.WriteLine("No solution found.");
            }

            Console.Read();
        }

        private static List<Path> Solve(string[][] maze, int target)
        {
            int startNum = Int32.Parse(maze[0][0]);

            Path startPath = new Path(new List<Point>(), startNum);
            startPath.Points.Add(new Point(0, 0));

            List<Path> currentDepth = new List<Path>() { startPath };

            // What have we already done? Used to prune.
            HashSet<Tuple<Point, int>> pointsSoFar = new HashSet<Tuple<Point, int>>();

            for (int numSteps = 1; numSteps < MaxSteps; ++numSteps)
            {
                IEnumerable<Path> solutions = currentDepth.Where(p => p.Points.Last().X == maze[0].Length - 1 && p.Points.Last().Y == maze.Length - 1 && p.Value == target);

                if (solutions.Any())
                {
                    return solutions.ToList();
                }

                List<Path> previousDepth = currentDepth;
                currentDepth = new List<Path>();

                foreach (Path path in previousDepth)
                {
                    Point current = path.Points.Last();

                    AddIfInBounds(maze, currentDepth, pointsSoFar, path, current.X - 1, current.Y);
                    AddIfInBounds(maze, currentDepth, pointsSoFar, path, current.X + 1, current.Y);
                    AddIfInBounds(maze, currentDepth, pointsSoFar, path, current.X, current.Y - 1);
                    AddIfInBounds(maze, currentDepth, pointsSoFar, path, current.X, current.Y + 1);
                }

                foreach(Path path in currentDepth)
                {
                    pointsSoFar.Add(new Tuple<Point, int>(path.Points.Last(), path.Value));
                }
            }

            return null;
        }

        private static void AddIfInBounds(string[][] maze, List<Path> currentDepth, HashSet<Tuple<Point, int>> pointsSoFar, Path path, int x, int y)
        {
            if (x == 0 && y == 0)
            {
                // Can't return to origin.
                return;
            }
            else if (x < 0 || x >= maze[0].Length || y < 0 || y >= maze.Length)
            {
                // Out of bounds.
                return;
            }
            else
            {
                Path potentialChild = path.CreateChild(new Point(x, y), maze[y][x]);

                Tuple<Point, int> potentialPoint = new Tuple<Point, int>(potentialChild.Points.Last(), potentialChild.Value);

                if (!pointsSoFar.Contains(potentialPoint))
                {
                    currentDepth.Add(potentialChild);
                }
            }
        }

        //public bool Recurse(string[][] maze, int currentNum, List<Point> resultPath)
        //{
        //    Point currentPoint = resultPath.Last();

        //    if (currentPoint.Y == maze.Length && currentPoint.X == maze[0].Length && currentNum == inputTarget)
        //    {
        //        return true;
        //    }

        //    if (currentPoint.X)
        //}
    }
}
