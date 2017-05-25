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

        public int X => _position.Item1;

        public int Y => _position.Item2;
    }
}