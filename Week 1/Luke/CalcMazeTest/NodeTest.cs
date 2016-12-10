namespace CalcMazeTest
{
    using CalcMaze;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void NodeHasDefaultLocation()
        {
            var node = new Node();
            node.x.Should().Be(-1);
            node.y.Should().Be(-1);
        }

        [TestMethod]
        public void NodeHasPostCalcStatus()
        {
            var node = new Node();
            node.CurrentCalc.Should().Be(0);
        }
    }
}