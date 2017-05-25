using System;
using System.Collections.Generic;

namespace Snake
{
    /// <summary>
    ///     A grid is the map in which the Snake game is played.
    ///     It can include a Snake and food.
    /// </summary>
    public class Grid
    {
        private static readonly Random lRand = new Random();
        private readonly char[,] _grid;
        private readonly Tuple<int, int> _gridSize;

        /// <summary>
        ///     The constructor can use any given grid size.
        /// </summary>
        /// <param name="gridSize">The size of the grid.</param>
        public Grid(Tuple<int, int> gridSize)
        {
            _gridSize = gridSize;
            _grid = new char[Width, Height];
            Items = new List<Item>();

            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                _grid[i, j] = (char) 0;
        }

        public SnakeObject SnakeObj { get; private set; }

        /// <summary>
        ///     Width of the grid.
        /// </summary>
        public int Width => Convert.ToInt32(_gridSize.Item1);

        /// <summary>
        ///     Height of the grid.
        /// </summary>
        public int Height => Convert.ToInt32(_gridSize.Item2);

        public List<Item> Items { get; }

        public int Score { get; private set; }

        public string Score_String => Score.ToString();

        /// <summary>
        ///     Run collision tests to grow snake and determine whether
        ///     or not the snake should die.
        /// </summary>
        /// <returns>Is snake alive.</returns>
        public bool CheckCollisions()
        {
            // Run food collision tests
            if (CheckCollision_Food())
                SnakeObj.Grow = true;

            // Check if snake is out of range or self-collision
            return CheckCollisions_Fatal();
        }

        private bool CheckCollisions_Fatal()
        {
            if (SnakeObj.IsSnakeNew)
                return false;

            if (SnakeObj.X < 0 || SnakeObj.X >= Width || SnakeObj.Y < 0 || SnakeObj.Y >= Height)
                return true;

            for (var i = 0; i < SnakeObj.SnakePos.Count - 1; i++)
                if (SnakeObj.SnakePos[i].Item1 == SnakeObj.X && SnakeObj.SnakePos[i].Item2 == SnakeObj.Y)
                    return true;

            return false;
        }

        private bool CheckCollision_Food()
        {
            foreach (var lI in Items)
                if (lI.X == SnakeObj.X && lI.Y == SnakeObj.Y)
                {
                    Items.Remove(lI);
                    CreateNewItem();
                    Score++;
                    return true;
                }

            return false;
        }

        /// <summary>
        ///     Creates a new food item in a random location
        /// </summary>
        private void CreateNewItem()
        {
            var lGridArray = new int[Width * Height];
            for (var i = 0; i < lGridArray.Length; i++)
                lGridArray[i] = i;
            foreach (var lT in SnakeObj.SnakePos)
                lGridArray[lT.Item2 * Width + lT.Item1] = -1;

            for (var i = 0; i < lGridArray.Length; i++)
            {
                var r = i + (int) (lRand.NextDouble() * (lGridArray.Length - i));
                var t = lGridArray[r];
                lGridArray[r] = lGridArray[i];
                lGridArray[i] = t;
            }
            for (var i = 0; i < lGridArray.Length; i++)
                if (lGridArray[i] != -1)
                {
                    Items.Add(new Food(lGridArray[i] % Width, (lGridArray[i] - lGridArray[i] % Width) / Height));
                    break;
                }
        }

        public void CommenceGame(int aSpeed = 15)
        {
            SnakeObj = new SnakeObject(_gridSize, aSpeed);
            CreateNewItem();
        }

        /// <summary>
        ///     View a particular location on the grid.
        /// </summary>
        /// <param name="pos">Position to investigate.</param>
        /// <returns>Value from given position.</returns>
        public char View(Tuple<int, int> pos)
        {
            return _grid[pos.Item1, pos.Item2];
        }
    }
}