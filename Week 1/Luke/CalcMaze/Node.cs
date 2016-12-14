namespace CalcMaze
{
    public class Node
    {
        public double CurrentCalc { get; set; }

        public Location Location { get; set; }
        public Node Previous { get; set; }
    }
}