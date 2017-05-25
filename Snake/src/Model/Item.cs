using System;

namespace Snake
{
    public class Item
    {
        private readonly Tuple<int, int> _position;

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