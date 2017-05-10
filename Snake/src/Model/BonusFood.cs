using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class BonusFood : Item
	{
		private int _lifetime;

		public BonusFood(int x, int y, int aLifetime) : base(x, y)
		{
			_lifetime = aLifetime;
		}
	}
}
