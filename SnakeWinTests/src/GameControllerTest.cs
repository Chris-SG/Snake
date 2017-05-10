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
            Assert.AreSame(x -1, s.RightPress());
        }

        [TestMethod]
        public void SnakeTurnLeft()
        {
            Assert.AreSame(x + 1, s.LeftPress());
        }

        [TestMethod]
        public void SnakeGoUp()
        {
            Assert.AreSame(y + 1, s.UpPress());
        }

        [TestMethod]
        public void SnakeGoDown()
        {
            Assert.AreSame(y - 1, s.DownPress());
        }


    }
}
