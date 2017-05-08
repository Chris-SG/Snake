using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyGameWinTests.src
{
    [TestClass]
    public class SnakeTest
    {
        Snake s = new Snake();

        [TestMethod]
        public void SpawnTest()
        {
            s.Spawn();
            Assert.AreEqual(2, s.length); // an initial snake equals 2 that includes head and body of the snake
        }

        [TestMethod]
        public void EatFoodTest()
        {
            s.EatFood();
            Assert.AreEqual(3, s.length);
        }
    }
}
