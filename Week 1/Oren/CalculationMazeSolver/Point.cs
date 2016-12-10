using System;

namespace CalculationMazeSolver
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.X, this.Y);
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Point))
            {
                return false;
            }

            Point p = obj as Point;

            return p.X == this.X && p.Y == this.Y;
        }
    }
}
