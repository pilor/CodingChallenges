namespace CalcMaze
{
    public class Location
    {
        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public CalcType CalcType { get; set; }

        public double CalcValue { get; set; }
    }
}