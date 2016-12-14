namespace CalcMazeTest
{
    using CalcMaze;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>Summary description for PuzzleTest</summary>
    [TestClass]
    public class PuzzleTest
    {
        [TestMethod]
        public void SolverTest()
        {
            string input = @"6
2 +2 -3
-1 *3 +3
+1 +4 +1";
            var puzzle = InputParser.Parse(input);
            puzzle.Solve().Should().Be("1 4 5 2 3 6 9");
        }

        [TestMethod]
        public void AddNeighbors00()
        {
            string input = @"6
2 +2 -3
-1 *3 +3
+1 +4 +1";
            Puzzle puzzle = InputParser.Parse(input);
            puzzle.AddNeighbors(0, 0);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[1][0]);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[0][1]);
        }

        [TestMethod]
        public void AddNeighbors10()
        {
            string input = @"6
2 +2 -3
-1 *3 +3
+1 +4 +1";
            Puzzle puzzle = InputParser.Parse(input);
            puzzle.AddNeighbors(1, 0);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[2][0]);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[1][1]);
            puzzle.LocationsToTry.Count.Should().Be(0);
        }

        [TestMethod]
        public void AddNeighbors20()
        {
            string input = @"6
2 +2 -3
-1 *3 +3
+1 +4 +1";
            Puzzle puzzle = InputParser.Parse(input);
            puzzle.AddNeighbors(2, 0);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[2][1]);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[1][0]);
            puzzle.LocationsToTry.Count.Should().Be(0);
        }

        [TestMethod]
        public void AddNeighbors01()
        {
            string input = @"6
2 +2 -3
-1 *3 +3
+1 +4 +1";
            Puzzle puzzle = InputParser.Parse(input);
            puzzle.AddNeighbors(0, 1);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[1][1]);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[0][2]);
            puzzle.LocationsToTry.Count.Should().Be(0);
        }

        [TestMethod]
        public void AddNeighbors11()
        {
            string input = @"6
2 +2 -3
-1 *3 +3
+1 +4 +1";
            Puzzle puzzle = InputParser.Parse(input);
            puzzle.AddNeighbors(1, 1);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[2][1]);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[1][2]);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[0][1]);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[1][0]);
            puzzle.LocationsToTry.Count.Should().Be(0);
        }

        [TestMethod]
        public void AddNeighbors21()
        {
            string input = @"6
2 +2 -3
-1 *3 +3
+1 +4 +1";
            Puzzle puzzle = InputParser.Parse(input);
            puzzle.AddNeighbors(2, 1);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[2][2]);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[1][1]);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[2][0]);
            puzzle.LocationsToTry.Count.Should().Be(0);
        }

        [TestMethod]
        public void AddNeighbors22()
        {
            string input = @"6
2 +2 -3
-1 *3 +3
+1 +4 +1";
            Puzzle puzzle = InputParser.Parse(input);
            puzzle.AddNeighbors(2, 2);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[1][2]);
            puzzle.LocationsToTry.Dequeue().Should().Be(puzzle.Map[2][1]);
            puzzle.LocationsToTry.Count.Should().Be(0);
        }
    }
}