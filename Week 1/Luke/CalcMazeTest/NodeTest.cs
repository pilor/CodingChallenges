namespace CalcMazeTest
{
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

    public class Node
    {
        public int x = -1;

        public int y = -1;

        public double CurrentCalc { get; set; }
    }
}