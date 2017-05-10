using System;
namespace Snake
{
	public class SnakeObject
	{
		private int _x;
		private int _y;
		private SnakeDirection _direction;
		private int _length;
		private int _lives;
		private Random rand;

		public int X {
			get { return _x; }
			set { _x = value; }
		}

		public int Y {
			get { return _y; }
			set { _y = value; }
		}

		public SnakeDirection Direction {
			get { return _direction; }
			set { _direction = value; }
		}

		public int Length {
			get { return _length; }
			set { _length = value; }
		}

		public int Lives {
			get { return _lives; }
			set { _lives = value; }
		}

		public Snake ()
		{
			_direction = SnakeDirection.Up;

		}

		public void Spawn ()
		{
			X = rand.Next ();
			Y = rand.Next ();
		}

		public void Movement ()
		{
			switch (Direction) {
			case SnakeDirection.Up:
				//negative y
				Y--;
				break;
			case SnakeDirection.Right:
				//positive x
				X++;
				break;
			case SnakeDirection.Down:
				//positive y
				Y++;
				break;
			case SnakeDirection.Left:
				//negative x
				X--;
				break;
			}
		}

		public void LengthIncrease ()
		{
			Length = Length + 1;
		}
	}
}