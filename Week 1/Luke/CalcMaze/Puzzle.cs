namespace CalcMaze
{
    using System.Collections.Generic;

    public class Puzzle
    {
        public Queue<Location> LocationsToTry = new Queue<Location>();

        public List<List<Location>> Map { get; set; }

        public double Goal { get; set; }

        public string Solve()
        {
            // Assuming that we always start at 0,0 and end at bottom right
            this.LocationsToTry.Enqueue(Map[0][0]);
            var root = new Node { CurrentCalc = Map[0][0].CalcValue, Location = Map[0][0] };
            return null;
        }

        public void AddNeighbors(int x, int y)
        {
            if (this.isValid(x + 1, y))
            {
                this.LocationsToTry.Enqueue(Map[x + 1][y]);
            }

            if (this.isValid(x, y + 1))
            {
                this.LocationsToTry.Enqueue(Map[x][y + 1]);
            }

            if (this.isValid(x - 1, y))
            {
                this.LocationsToTry.Enqueue(Map[x - 1][y]);
            }

            if (this.isValid(x, y - 1))
            {
                this.LocationsToTry.Enqueue(Map[x][y - 1]);
            }
        }

        private bool isValid(int x, int y)
        {
            return (x >= 0) && (y >= 0) && (y < this.Map.Count) && (x < this.Map[y].Count) && !((x == 0) && (y == 0));
        }
    }
}