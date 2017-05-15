namespace CalcMazeTest
{
    using CalcMaze;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GridTest
    {
        [TestMethod]
        public void GridCanBeCreated()
        {
            var grid = new Location[1, 1];
            grid[0, 0] = new Location(0, 0) { CalcType = CalcType.Plus, CalcValue = 7 };
        }
    }
}