using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Snake.Tests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void GridSizeTest()
        {
            var grid = new Grid(new Tuple<int, int>(10, 10));

            Assert.AreEqual(grid.Height, 10);
            Assert.AreEqual(grid.Width, 10);
        }

        [TestMethod]
        public void GridHasSnakeTest()
        {
            var grid = new Grid(new Tuple<int, int>(10, 10));
            grid.CommenceGame();

            Assert.IsTrue(grid.SnakeObj.X == 5 && grid.SnakeObj.Y == 5);
        }

        [TestMethod]
        public void GridFullTest()
        {
            var grid = new Grid(new Tuple<int, int>(1, 1));
            grid.CommenceGame();

            Assert.IsTrue(grid.SnakeObj.X == 0 && grid.SnakeObj.Y == 0);
        }

        [TestMethod]
        public void GridItemDeploymentTest()
        {
            var grid = new Grid(new Tuple<int, int>(10, 10));
            grid.CommenceGame();

            Assert.IsTrue(grid.Items.Count > 0, "No items created");
        }

        [TestMethod]
        public void GridItemDeploymentClashTest()
        {
            var grid = new Grid(new Tuple<int, int>(10, 10));
            grid.CommenceGame();

            foreach (var lItem in grid.Items)
                Assert.IsFalse(lItem.X == grid.SnakeObj.X && lItem.Y == grid.SnakeObj.Y,
                    "Item placed on top of the snake");
            
        }

        [TestMethod()]
        public void ScoreIncreases()
        {
            Grid grid = new Grid(new Tuple<int, int>(1, 2));
            grid.CommenceGame();

            grid.SnakeObj.Direction = SnakeDirection.Up;

            for (int i = 0; i < 15; i++)
            {
                grid.SnakeObj.Movement();
            }

            grid.CheckCollisions();

            Assert.AreEqual(1, grid.Score);
        }
    }
}
