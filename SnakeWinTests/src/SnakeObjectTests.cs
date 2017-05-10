using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Snake
{
    [TestClass]
    public class SnakeObjectTests
    {
        [TestMethod]
        public void LengthTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);
            snake.Grow = true;

            for(int i = 0; i < 60; i++)
            {
                snake.Movement();
            }

			Assert.AreEqual(2, snake.Length);
        }

        [TestMethod]
        public void MovementTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);
            
            Assert.IsTrue(snake.X == 3 && snake.Y == 3);

        }
    }
}
