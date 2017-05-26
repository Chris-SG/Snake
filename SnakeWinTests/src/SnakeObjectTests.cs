using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Snake
{
    [TestClass]
    public class SnakeObjectTests
    {
        [TestMethod]
        public void LengthTest()
        {
            var snake = new SnakeObject(6, 6);
            snake.Grow = true;

            for (var i = 0; i < 60; i++)
                snake.Movement();

            Assert.AreEqual(4, snake.Length);
        }

        [TestMethod]
        public void SpawnTest()
        {
            var snake = new SnakeObject(6, 6);

            Assert.IsTrue(snake.X == 3 && snake.Y == 3);
        }

        [TestMethod]
        public void MovementTest()
        {
            var snake = new SnakeObject(6, 6);
            snake.Direction = SnakeDirection.Down;


            for (var i = 0; i < 15; i++)
                snake.Movement();

            Assert.IsTrue(snake.X == 3 && snake.Y == 4);
        }

        [TestMethod]
        public void DirectionDefaultTest()
        {
            var snake = new SnakeObject(6, 6);

            Assert.AreEqual(SnakeDirection.Right, snake.Direction, "Default direction is not working");
        }

        [TestMethod]
        public void DirectionR2DTest()
        {
            var snake = new SnakeObject(6, 6);


            snake.Direction = SnakeDirection.Down;

            for (var i = 0; i < 15; i++)
                snake.Movement();

            Assert.AreEqual(SnakeDirection.Down, snake.Direction, "Snake failed to turn down");
        }

        [TestMethod]
        public void DirectionD2LTest()
        {
            var snake = new SnakeObject(6, 6);

            snake.Direction = SnakeDirection.Down;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Left;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            Assert.AreEqual(SnakeDirection.Left, snake.Direction, "Snake failed to turn Left");
        }

        [TestMethod]
        public void DirectionL2UTest()
        {
            var snake = new SnakeObject(6, 6);

            snake.Direction = SnakeDirection.Down;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Left;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Up;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            Assert.AreEqual(SnakeDirection.Up, snake.Direction, "Snake failed to turn up");
        }

        [TestMethod]
        public void DirectionU2RTest()
        {
            var snake = new SnakeObject(6, 6);

            snake.Direction = SnakeDirection.Down;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Left;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Up;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Right;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            Assert.AreEqual(SnakeDirection.Right, snake.Direction, "Snake failed to turn right");
        }

        [TestMethod]
        public void RestrictedDirectionR2LTest()
        {
            var snake = new SnakeObject(6, 6);

            snake.Direction = SnakeDirection.Left;

            Assert.AreNotEqual(SnakeDirection.Left, snake.Direction, "Snake accidentally turned into itself");
        }

        [TestMethod]
        public void RestrictedDirectionL2RTest()
        {
            var snake = new SnakeObject(6, 6);

            snake.Direction = SnakeDirection.Down;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Left;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Right;

            Assert.AreNotEqual(SnakeDirection.Right, snake.Direction, "Snake accidentally turned into itself");
        }

        [TestMethod]
        public void RestrictedDirectionU2DTest()
        {
            var snake = new SnakeObject(6, 6);


            snake.Direction = SnakeDirection.Up;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Down;

            Assert.AreNotEqual(SnakeDirection.Down, snake.Direction, "Snake accidentally turned into itself");
        }

        [TestMethod]
        public void RestrictedDirectionD2UTest()
        {
            var snake = new SnakeObject(6, 6);

            snake.Direction = SnakeDirection.Down;
            for (var i = 0; i < 15; i++)
                snake.Movement();

            snake.Direction = SnakeDirection.Up;

            Assert.AreNotEqual(SnakeDirection.Up, snake.Direction, "Snake accidentally turned into itself");
        }


        [TestMethod]
        public void ExtendedMovementTest()
        {
            var snake = new SnakeObject(6, 6);
            snake.Direction = SnakeDirection.Down;

            for (var i = 0; i < 15; i++)
                snake.Movement();

            Assert.IsTrue(snake.X == 3 && snake.Y == 4);
            snake.Direction = SnakeDirection.Left;

            for (var i = 0; i < 15; i++)
                snake.Movement();

            Assert.IsTrue(snake.X == 2 && snake.Y == 4);
        }
    }
}