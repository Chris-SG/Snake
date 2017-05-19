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

        [TestMethod()]
        public void GridFullTest()
        {
            Grid grid = new Grid(new Tuple<int, int>(1, 1));
            grid.CommenceGame();

            Assert.IsTrue(grid.SnakeObj.X == 0 && grid.SnakeObj.Y == 0);
        }

        [TestMethod()]
        public void GridItemDeploymentTest()
        {
            Grid grid = new Grid(new Tuple<int, int>(10, 10));
            grid.CommenceGame();
            //need to know the functions to deploy food
        }

        [TestMethod()]
        public void GridItemDeploymentClashTest()
        {
            Grid grid = new Grid(new Tuple<int, int>(10, 10));
            grid.CommenceGame();
            //need to know the functions to deploy food
            //check if there is a clash of items
        }

    }
}