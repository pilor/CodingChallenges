namespace CalcMazeTest
{
    using System.Collections.Generic;

    using CalcMaze;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InputTest
    {
        [TestMethod]
        public void ReadInTest()
        {
            string input = @"6
2 +2 -3
-1 *3 +3
+1 +4 +1";
            Puzzle puzzle = InputParser.Parse(input);
            var map = puzzle.Map;
            puzzle.Goal.Should().Be(6);
            map[0][0].CalcValue.Should().Be(2);
            map[0][1].CalcValue.Should().Be(2);
            map[0][1].CalcType.Should().Be(CalcType.Plus);

            map[0][2].CalcValue.Should().Be(3);
            map[0][2].CalcType.Should().Be(CalcType.Minus);

            map[1][0].CalcValue.Should().Be(1);
            map[1][0].CalcType.Should().Be(CalcType.Minus);

            map[1][1].CalcValue.Should().Be(3);
            map[1][1].CalcType.Should().Be(CalcType.Mult);

            map[1][2].CalcValue.Should().Be(3);
            map[1][2].CalcType.Should().Be(CalcType.Plus);

            map[2][0].CalcValue.Should().Be(1);
            map[2][0].CalcType.Should().Be(CalcType.Plus);
        }
    }
}