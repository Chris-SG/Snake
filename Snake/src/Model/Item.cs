using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	public class Item
	{
		Tuple<int, int> _position;

		protected Item(int x, int y)
		{
			_position = new Tuple<int, int>(x, y);
		}

		public int X
		{
			get { return _position.Item1; }
		}

		public int Y
		{
			get { return _position.Item2; }
		}
	}
}
