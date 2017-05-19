using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace Snake
{
	public class SnakeObject
	{
		private Tuple<int, int> _snakePos;
		private SnakeDirection _direction, _directionToMove;
		private int _lives;
		private int _moveCounter;
		private bool _grow;
		private List<Tuple<int, int>> _movementQueue;
		private bool _isSnakeNew;
		private int _speed;

		public SnakeObject(Tuple<int,int> aGridSize, int aSpeed = 15)
		{
			_snakePos = new Tuple<int, int>((aGridSize.Item1 / 2), (aGridSize.Item2 / 2));
			_speed = aSpeed;
			Initialize();
		}
		
		public SnakeObject(int x, int y, int aSpeed = 15)
		{
			_snakePos = new Tuple<int, int>((x/2), (y/2));
			_speed = aSpeed;
			Initialize();
		}

		private void Initialize()
		{
			_movementQueue = new List<Tuple<int, int>>();

			for (int i = 0; i < 3; i++)
			{
				_movementQueue.Add(_snakePos);
			}
			_directionToMove = SnakeDirection.Right;
			_direction = _directionToMove;
			_grow = false;
			_moveCounter = _speed;
			_isSnakeNew = true;
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
			set { _directionToMove = value; }
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

		public bool IsSnakeNew
		{
			get { return _isSnakeNew; }
		}

		public void Movement ()
		{
			if(--_moveCounter == 0)
			{
				_isSnakeNew = false;
				_moveCounter = _speed;
			    _direction = _directionToMove;

                //TODO: Maybe set a snake part length 50 to make it move faster
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
						_snakePos = new Tuple<int, int>(_snakePos.Item1, _snakePos.Item2+1);
						_movementQueue.Add(_snakePos);
						break;
					case SnakeDirection.Left:
						//negative x
						_snakePos = new Tuple<int, int>(_snakePos.Item1-1, _snakePos.Item2);
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