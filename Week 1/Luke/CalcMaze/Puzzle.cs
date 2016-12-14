using System;

namespace CalcMaze
{
    using System.Collections.Generic;

    public class Puzzle
    {
        public Queue<Node> LocationsToTry = new Queue<Node>();

        public List<List<Location>> Map { get; set; }

        public double Goal { get; set; }

        public string Solve()
        {
            // Assuming that we always start at 0,0 and end at bottom right
            var root = new Node { CurrentCalc = Map[0][0].CalcValue, Location = Map[0][0], Path = "0,0" };
            this.LocationsToTry.Enqueue(root);
            while (this.LocationsToTry.Peek() != null)
            {
                var next = this.LocationsToTry.Dequeue();
                var neighbors = GetValidNeighbors(next.Location.X, next.Location.Y);
                foreach (var neighbor in neighbors)
                {
                    double nextCalc = DoCalc(next.CurrentCalc, neighbor);
                    string nextLocation = next.Path + " " + neighbor.X + "," + neighbor.Y;
                    if (nextCalc == this.Goal && neighbor.X == Map[0].Count && neighbor.Y == Map.Count)
                    {
                        return nextLocation;
                    }
                    else
                    {
                        this.LocationsToTry.Enqueue(new Node() { CurrentCalc = nextCalc, Location = neighbor, Path = nextLocation });
                    }
                }
            }


            return null;
        }

        private double DoCalc(double next, Location neighbor)
        {
            switch (neighbor.CalcType)
            {
                case CalcType.Minus:
                    return next - neighbor.CalcValue;
                case CalcType.Plus:
                    return next + neighbor.CalcValue;
                case CalcType.Mult:
                    return next * neighbor.CalcValue;
                default:
                    throw new ApplicationException("No calc type WTF");
            }
        }

        public List<Location> GetValidNeighbors(int x, int y)
        {
            var locs = new List<Location>();
            if (this.isValid(x + 1, y))
            {
                locs.Add(Map[x + 1][y]);
            }

            if (this.isValid(x, y + 1))
            {
                locs.Add(Map[x][y + 1]);
            }

            if (this.isValid(x - 1, y))
            {
                locs.Add(Map[x - 1][y]);
            }

            if (this.isValid(x, y - 1))
            {
                locs.Add(Map[x][y - 1]);
            }

            return locs;
        }

        private bool isValid(int x, int y)
        {
            return (x >= 0) && (y >= 0) && (y < this.Map.Count) && (x < this.Map[y].Count) && !((x == 0) && (y == 0));
        }
    }
}