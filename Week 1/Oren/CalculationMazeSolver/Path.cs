using System;
using System.Collections.Generic;

namespace CalculationMazeSolver
{
    public class Path
    {
        public Path(List<Point> points, int value)
        {
            this.Points = points;
            this.Value = value;
        }

        public Path CreateChild(Point point, string square)
        {
            List<Point> newPoints = new List<Point>(this.Points);
            newPoints.Add(point);
            int newValue = Eval(this.Value, square);

            return new Path(newPoints, newValue);
        }

        public List<Point> Points { get; private set; }

        public int Value { get; set; }

        /// <summary>
        /// Evaluate an input against a single operation in a square.
        /// </summary>
        private static int Eval(int input, string square)
        {
            int num = Int32.Parse(square.Substring(1));

            switch (square[0])
            {
                case '+':
                    return input + num;
                case '-':
                    return input - num;
                case 'x':
                case '*':
                    return input * num;
                default:
                    throw new InvalidOperationException("Unknown operation: " + square[0]);
            }
        }
    }
}
