using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace Snake
{
	public class SnakeObject
	{
		private Tuple<int, int> _snakePos;
		private SnakeDirection _direction;
		private int _lives;
		private int _moveCounter;
		private bool _grow;
		private List<Tuple<int, int>> _movementQueue;

		public SnakeObject(Point2D aGridSize)
		{
			_snakePos = new Tuple<int, int>(Convert.ToInt32(Math.Ceiling(aGridSize.X / 2)), Convert.ToInt32(Math.Ceiling(aGridSize.Y / 2)));
			_movementQueue = new List<Tuple<int, int>>();
			_movementQueue.Add(_snakePos);
			_direction = SnakeDirection.Right;
			_grow = false;
			_moveCounter = 30;
		}

		public SnakeObject(int x, int y)
		{
			_snakePos = new Tuple<int, int>(x, y);
			_movementQueue = new List<Tuple<int, int>>();
			_movementQueue.Add(_snakePos);
			_direction = SnakeDirection.Right;
			_grow = false;
			_moveCounter = 30;
		}

		public int X {
			get { return _snakePos.Item1; }
		}

		public bool Grow
		{
			set { _grow = value; }
		}

		public int Y {
			get { return _snakePos.Item2; ; }
		}

		public SnakeDirection Direction {
			get { return _direction; }
			set { _direction = value; }
		}

		public int Length {
			get { return _movementQueue.Count; }
		}

		public List<Tuple<int, int>> SnakePos
		{
			get { return _movementQueue; }
		}

		public int Lives {
			get { return _lives; }
			set { _lives = value; }
		}

		public void Movement ()
		{
			if(--_moveCounter == 0)
			{
				_moveCounter = 30;

				switch (Direction)
				{
					case SnakeDirection.Up:
						//negative y
						_snakePos = new Tuple<int, int>(_snakePos.Item1, _snakePos.Item2-1);
						_movementQueue.Add(_snakePos);
						break;
					case SnakeDirection.Right:
						//positive x
						_snakePos = new Tuple<int, int>(_snakePos.Item1+1, _snakePos.Item2);
						_movementQueue.Add(_snakePos);
						break;
					case SnakeDirection.Down:
						//positive y
						_snakePos = new Tuple<int, int>(_snakePos.Item1+1, _snakePos.Item2);
						_movementQueue.Add(_snakePos);
						break;
					case SnakeDirection.Left:
						//negative x
						_snakePos = new Tuple<int, int>(_snakePos.Item1, _snakePos.Item2 - 1);
						_movementQueue.Add(_snakePos);
						break;
				}

				if (_grow != true)
				{
					_movementQueue.RemoveAt(0);
				}
				_grow = false;
			}
		}
	}
}