namespace CalcMazeTest
{
    using CalcMaze;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void NodeHasPostCalcStatus()
        {
            var node = new Node();
            node.CurrentCalc.Should().Be(0);
        }
    }
}