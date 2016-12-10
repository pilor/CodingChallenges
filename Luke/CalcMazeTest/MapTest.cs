// // ---------------------------------------------------------------------------
// // <copyright file="MapTest.cs" company="Microsoft">
// //     Copyright (c) Microsoft Corporation.  All rights reserved.
// // </copyright>
// // ---------------------------------------------------------------------------

namespace CalcMazeTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    class MapTest
    {
        #region Public Methods and Operators

        [TestMethod]
        public void TestMap()
        {
            var foo = new Map { Grid = new Location[1, 1] };
            foo.Grid[0, 0] = new Location() { CalcType = CalcType.Plus };
        }

        #endregion
    }

    public enum CalcType
    {
        Plus
    }

    public class Location
    {
        public CalcType CalcType { get; set; }
    }

    public class Map
    {
        public Location[,] Grid { get; set; }
    }
}