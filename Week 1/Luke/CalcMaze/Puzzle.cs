using System;
using System.Collections.Generic;

namespace CalcMaze
{
    public class Puzzle
    {
        public Queue<Node> LocationsToTry = new Queue<Node>();

        public List<List<Location>> Map { get; set; }

        public double Goal { get; set; }

        public Node Solve()
        {
            // Assuming that we always start at 0,0 and end at bottom right
            var root = new Node
            {
                CurrentCalc = Map[0][0].CalcValue,
                Location = Map[0][0],
                Previous = null
            };
            LocationsToTry.Enqueue(root);
            while (LocationsToTry.Peek() != null)
            {
                var currentNode = LocationsToTry.Dequeue();
                var neighbors = GetValidNeighbors(currentNode.Location.Row, currentNode.Location.Col);
                foreach (var neighbor in neighbors)
                {
                    var nextCalc = DoCalc(currentNode.CurrentCalc, neighbor);
                    var nextNode = new Node {CurrentCalc = nextCalc, Location = neighbor, Previous = currentNode};
                    if (nextCalc == Goal && neighbor.Row == Map.Count - 1 && neighbor.Col == Map[0].Count - 1)
                    {
                        return nextNode;
                    }

                    LocationsToTry.Enqueue(nextNode);
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
                    return next*neighbor.CalcValue;
                default:
                    throw new ApplicationException("No calc type WTF");
            }
        }

        public List<Location> GetValidNeighbors(int row, int col)
        {
            var locs = new List<Location>();
            if (isValid(row + 1, col))
            {
                locs.Add(Map[row + 1][col]);
            }

            if (isValid(row, col + 1))
            {
                locs.Add(Map[row][col + 1]);
            }

            if (isValid(row - 1, col))
            {
                locs.Add(Map[row - 1][col]);
            }

            if (isValid(row, col - 1))
            {
                locs.Add(Map[row][col - 1]);
            }

            return locs;
        }

        private bool isValid(int row, int col)
        {
            return (row >= 0) && (col >= 0) && (row < Map.Count) && (col < Map[row].Count) && !((row == 0) && (col == 0));
        }
    }
}