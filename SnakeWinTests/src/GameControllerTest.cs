using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Snake.src
{
    [TestClass]
    public class GameControllerTest
    {
        [TestMethod]
        public void SnakeTurnRight()
        {
            Grid grid = new Grid(new Tuple<int, int>(10, 10));
            SnakeObject snake = new SnakeObject(5, 5);

        }

        [TestMethod]
        public void SnakeTurnLeft()
        {
        }

        [TestMethod]
        public void SnakeGoUp()
        {
        }

        [TestMethod]
        public void SnakeGoDown()
        {
        }


    }
}
