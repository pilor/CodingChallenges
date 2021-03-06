namespace CalcMaze
{
    public class Location
    {
        public Location(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; }

        public int Col { get; }

        public CalcType CalcType { get; set; }

        public double CalcValue { get; set; }

        public int TranslateLocation(Puzzle puzzle)
        {
            return Row*puzzle.Map[0].Count + Col + 1;
        }
    }
}