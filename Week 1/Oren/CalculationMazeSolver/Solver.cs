using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CalculationMazeSolver
{
    class Solver
    {
        public static string SolveFile(string path)
        {
            StringBuilder output = new StringBuilder();

            string[] fileContent = File.ReadAllLines(path);

            if (fileContent.Length < 2)
            {
                throw new InvalidOperationException("Invalid input.");
            }

            int inputTarget = Int32.Parse(fileContent[0]);

            string[][] maze = fileContent.Skip(1).Select(l => l.Split(' ')).ToArray();

            List<Path> solutions = Solve(maze, inputTarget);

            if (solutions != null)
            {
                output.AppendLine(solutions[0].Points.Count.ToString());

                // Format used by the site
                foreach (Path solution in solutions)
                {
                    //Console.WriteLine(String.Concat(solution.Points.Select(p => maze[p.Y][p.X])) + "=" + solution.Value);
                    output.AppendLine(String.Join(" ", solution.Points.Select(p => p.X + 1 + (maze.Length * p.Y))));
                }
            }
            else
            {
                output.AppendLine("No solution found.");
            }

            return output.ToString();
        }

        private static List<Path> Solve(string[][] maze, int target)
        {
            int startNum = Int32.Parse(maze[0][0]);

            Path startPath = new Path(new List<Point>(), startNum);
            startPath.Points.Add(new Point(0, 0));

            List<Path> currentDepth = new List<Path>() { startPath };

            // What have we already done? Used to prune.
            HashSet<Tuple<Point, int>> pointsSoFar = new HashSet<Tuple<Point, int>>();

            for (int numSteps = 1; numSteps < 17; ++numSteps)
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
                    // TODO remove
                    Point current = path.Points.Last();

                    AddIfInBounds(maze, currentDepth, pointsSoFar, path, current.X - 1, current.Y);
                    AddIfInBounds(maze, currentDepth, pointsSoFar, path, current.X + 1, current.Y);
                    AddIfInBounds(maze, currentDepth, pointsSoFar, path, current.X, current.Y - 1);
                    AddIfInBounds(maze, currentDepth, pointsSoFar, path, current.X, current.Y + 1);
                }

                foreach(Path path in currentDepth)
                {
                    if (path.Points.Last().X == maze[0].Length - 1 && path.Points.Last().Y == maze.Length - 1 && numSteps == 16 && path.Value >= 0 && path.Value < 1000)
                    {
                        Console.WriteLine("Unique value: " + path.Value);
                    }

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
    }
}
