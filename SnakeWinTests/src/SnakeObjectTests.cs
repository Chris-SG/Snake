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
        public void DirectionDefaultTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);
            
            Assert.AreEqual(SnakeDirection.Right, snake.Direction, "Default direction is not working");
            
        }

        [TestMethod]
        public void DirectionR2DTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);
            

            snake.Direction = SnakeDirection.Down;

            for (int i = 0; i < 15; i++)
                snake.Movement();

            Assert.AreEqual(SnakeDirection.Down, snake.Direction, "Snake failed to turn down");
        }

        [TestMethod]
        public void DirectionD2LTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);

            snake.Direction = SnakeDirection.Down;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Left;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            Assert.AreEqual(SnakeDirection.Left, snake.Direction, "Snake failed to turn Left");

        }

        [TestMethod]
        public void DirectionL2UTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);

            snake.Direction = SnakeDirection.Down;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Left;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Up;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            Assert.AreEqual(SnakeDirection.Up, snake.Direction, "Snake failed to turn up");

        }

        [TestMethod]
        public void DirectionU2RTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);

            snake.Direction = SnakeDirection.Down;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Left;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Up;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Right;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            Assert.AreEqual(SnakeDirection.Right, snake.Direction, "Snake failed to turn right");

        }

        [TestMethod]
        public void RestrictedDirectionR2LTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);

            snake.Direction = SnakeDirection.Left;
           
            Assert.AreNotEqual(SnakeDirection.Left, snake.Direction, "Snake accidentally turned into itself");

        }

        [TestMethod]
        public void RestrictedDirectionL2RTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);

            snake.Direction = SnakeDirection.Down;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Left;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Right;
           
            Assert.AreNotEqual(SnakeDirection.Right, snake.Direction, "Snake accidentally turned into itself");
            
        }

        [TestMethod]
        public void RestrictedDirectionU2DTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);

<<<<<<< HEAD
            snake.Direction = SnakeDirection.Up;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Down;
            
            Assert.AreNotEqual(SnakeDirection.Down, snake.Direction, "Snake accidentally turned into itself");

=======
            //snake.Direction = SnakeDirection.Up;

            //Assert.AreEqual(SnakeDirection.Up, snake.Direction);
>>>>>>> Tests
        }

        [TestMethod]
        public void RestrictedDirectionD2UTest()
        {
            SnakeObject snake = new SnakeObject(6, 6);

            snake.Direction = SnakeDirection.Down;
            for (int i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Up;
            
            Assert.AreNotEqual(SnakeDirection.Up, snake.Direction, "Snake accidentally turned into itself");

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
