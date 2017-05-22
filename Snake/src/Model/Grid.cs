using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SwinGameSDK;

namespace Snake
{
    /// <summary>
    /// A grid is the map in which the Snake game is played.
    /// It can include a Snake and food.
    /// </summary>
    public class Grid
    {
        private Tuple<int,int> _gridSize;
        private char[,] _grid;
		private List<Item> _items;
		private SnakeObject _snake;

        /// <summary>
        /// The constructor can use any given grid size.
        /// </summary>
        /// <param name="gridSize">The size of the grid.</param>
        public Grid(Tuple<int,int> gridSize)
        {
            _gridSize = gridSize;
            _grid = new char[Width, Height];
			_items = new List<Item>();

			for (int i = 0; i < Width; i++)
            {
                for(int j = 0; j < Height; j++)
                {
                    _grid[i, j] = (char)0;
                }
            }
        }

		/// <summary>
		/// Run collision tests to grow snake and determine whether
		/// or not the snake should die.
		/// </summary>
		/// <returns>Is snake alive.</returns>
		public bool CheckCollisions()
		{
			// Run food collision tests
			if(CheckCollision_Food())
			{
				_snake.Grow = true;
			}

			// Check if snake is out of range or self-collision
			return CheckCollisions_Fatal();
		}

		private bool CheckCollisions_Fatal()
		{
			if(_snake.IsSnakeNew)
			{
				return false;
			}

			if (_snake.X < 0 || _snake.X >= Width || _snake.Y < 0 || _snake.Y >= Height)
			{
				return true;
			}

			for(int i = 0; i < _snake.SnakePos.Count-1; i++)
			{
				if(_snake.SnakePos[i].Item1 == _snake.X && _snake.SnakePos[i].Item2 == _snake.Y)
				{
					return true;
				}
			}

			return false;
		}
		
		private bool CheckCollision_Food()
		{
			foreach(Item lI in _items)
			{
				if (lI.X == _snake.X && lI.Y == _snake.Y)
				{
					_items.Remove(lI);
					CreateNewItem();
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Creates a new food item in a random location
		/// </summary>
		private void CreateNewItem()
		{
			int[] lGridArray = new int[Width * Height];
			for (int i = 0; i < lGridArray.Length; i++)
			{
				lGridArray[i] = i;
			}
			foreach (Tuple<int, int> lT in _snake.SnakePos)
			{
				lGridArray[(lT.Item2) * Width + lT.Item1] = -1;
			}
			Random lRand = new Random();
			for (int i = 0; i < lGridArray.Length; i++)
			{
				int r = i + (int)(lRand.NextDouble() * (lGridArray.Length - i));
				int t = lGridArray[r];
				lGridArray[r] = lGridArray[i];
				lGridArray[i] = t;
			}
			for (int i = 0; i < lGridArray.Length; i++)
			{
				if (lGridArray[i] != -1)
				{
					_items.Add(new Food(lGridArray[i] % Width, (lGridArray[i] - (lGridArray[i] % Width)) / Height));
					break;
				}
			}
		}

		public void CommenceGame(int aSpeed = 15)
		{
			_snake = new SnakeObject(_gridSize, aSpeed);
			CreateNewItem();
		}

		public SnakeObject SnakeObj
		{
			get { return _snake; }
		}

        /// <summary>
        /// Width of the grid.
        /// </summary>
        public int Width
        {
            get
            {
                return Convert.ToInt32(_gridSize.Item1);
            }
        }
        
        /// <summary>
        /// Height of the grid.
        /// </summary>
        public int Height
        {
            get
            {
                return Convert.ToInt32(_gridSize.Item2);
            }
        }

        /// <summary>
        /// View a particular location on the grid.
        /// </summary>
        /// <param name="pos">Position to investigate.</param>
        /// <returns>Value from given position.</returns>
        public char View(Tuple<int,int> pos)
        {
			return _grid[pos.Item1, pos.Item2];
        }

		public List<Item> Items
		{
			get
			{
				return _items;
			}
		}
        
    }
}
