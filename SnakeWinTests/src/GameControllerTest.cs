using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;

namespace Snake
{
    [TestClass]
    public class GameControllerTest
    {
        [TestMethod]
        public void StartGameTest()
        {
<<<<<<< HEAD
<<<<<<< HEAD
            Grid grid = new Grid(new Tuple<int, int>(10, 10));
            grid.CommenceGame();
=======
          
=======
            Grid grid = new Grid(new Tuple<int, int>(10, 10));
            SnakeObject snake = new SnakeObject(5, 5);

>>>>>>> Tests
        }
>>>>>>> Tests

            Assert.IsNotNull(grid.SnakeObj, "Where's the snake?");
            Assert.IsTrue(grid.Items.Count > 0, "No items here");

            Assert.IsTrue(grid.SnakeObj.X == 5 && grid.SnakeObj.Y == 5);

        }

        


    }
}
