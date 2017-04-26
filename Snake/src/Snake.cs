using System;
namespace MyGame
{
	public class Snake
	{
		private int _x;
		private int _y;
		private SnakeDirection _direction;
		private int _length;

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
		}

		public int Length {
			get { return _length; }
			set { _length = value; }
		}

		public Snake ()
		{

		}

		public void Spawn ()
		{
			
		}
	}
}
