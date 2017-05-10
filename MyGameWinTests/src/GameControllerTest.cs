using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyGameWinTests.src
{
    [TestClass]
    public class GameControllerTest
    {
        Snake s = new Snake();
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
