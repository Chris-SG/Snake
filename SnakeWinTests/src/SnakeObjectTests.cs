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

			Assert.AreEqual(4, snake.Length);
        }

        [TestMethod]
        public void SpawnTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);
            
            Assert.IsTrue(snake.X == 3 && snake.Y == 3);
        }

        [TestMethod]
        public void MovementTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);
            snake.Direction = SnakeDirection.Down;


            for(int i = 0; i < 15; i++)
                snake.Movement();

            Assert.IsTrue(snake.X == 3 && snake.Y == 4);

        }

        [TestMethod]
        public void DefaultDirectionTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);
            
            Assert.AreEqual(SnakeDirection.Right, snake.Direction);
            
        }


        [TestMethod]
        public void ExtendedMovementTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);
            snake.Direction = SnakeDirection.Down;

            for (int i = 0; i < 15; i++)
                snake.Movement();

            Assert.IsTrue(snake.X == 3 && snake.Y == 4);
            snake.Direction = SnakeDirection.Left;

            for (int i = 0; i < 15; i++)
                snake.Movement();

            Assert.IsTrue(snake.X == 2 && snake.Y == 4);

        }

    }
}
