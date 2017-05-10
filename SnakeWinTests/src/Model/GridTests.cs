using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Tests
{
    [TestClass()]
    public class GridTests
    {
        [TestMethod()]
        public void GridSizeTest()
        {
            Grid grid = new Grid(new Tuple<int, int>(10, 10));

            Assert.AreEqual(grid.Height, 10);
            Assert.AreEqual(grid.Width, 10);
        }

        [TestMethod()]
        public void GridHasSnakeTest()
        {
            Grid grid = new Grid(new Tuple<int, int>(10, 10));
            grid.CommenceGame();
            
            Assert.IsTrue(grid.SnakeObj.X == 5 && grid.SnakeObj.Y == 5);            
        }
    }
}