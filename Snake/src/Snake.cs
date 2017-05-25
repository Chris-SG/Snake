using System;
using System.Collections.Generic;

namespace Snake
{
    public class SnakeObject
    {
        private SnakeDirection _direction, _directionToMove;
        private bool _grow;
        private int _moveCounter;
        private Tuple<int, int> _snakePos;
        private readonly int _speed;

        public SnakeObject(Tuple<int, int> aGridSize, int aSpeed = 15)
        {
            _snakePos = new Tuple<int, int>(aGridSize.Item1 / 2, aGridSize.Item2 / 2);
            _speed = aSpeed;
            Initialize();
        }

        public SnakeObject(int x, int y, int aSpeed = 15)
        {
            _snakePos = new Tuple<int, int>(x / 2, y / 2);
            _speed = aSpeed;
            Initialize();
        }

        public int X => _snakePos.Item1;

        public bool Grow
        {
            set => _grow = value;
        }

        public int Y => _snakePos.Item2;

        public SnakeDirection Direction
        {
            get => _direction;
            set => _directionToMove = value;
        }

        public int Length => SnakePos.Count;

        public List<Tuple<int, int>> SnakePos { get; private set; }

        public int Lives { get; set; }

        public bool IsSnakeNew { get; private set; }

        private void Initialize()
        {
            SnakePos = new List<Tuple<int, int>>();

            for (var i = 0; i < 3; i++)
                SnakePos.Add(_snakePos);
            _directionToMove = SnakeDirection.Right;
            _direction = _directionToMove;
            _grow = false;

            _moveCounter = _speed;

            IsSnakeNew = true;
        }

        public void Movement()
        {
            if (--_moveCounter == 0)
            {
                IsSnakeNew = false;
                _moveCounter = _speed;
                _direction = _directionToMove;

                //TODO: Maybe set a snake part length 50 to make it move faster
                switch (Direction)
                {
                    case SnakeDirection.Up:
                        //negative y
                        _snakePos = new Tuple<int, int>(_snakePos.Item1, _snakePos.Item2 - 1);
                        SnakePos.Add(_snakePos);
                        break;
                    case SnakeDirection.Right:
                        //positive x
                        _snakePos = new Tuple<int, int>(_snakePos.Item1 + 1, _snakePos.Item2);
                        SnakePos.Add(_snakePos);
                        break;
                    case SnakeDirection.Down:
                        //positive y
                        _snakePos = new Tuple<int, int>(_snakePos.Item1, _snakePos.Item2 + 1);
                        SnakePos.Add(_snakePos);
                        break;
                    case SnakeDirection.Left:
                        //negative x
                        _snakePos = new Tuple<int, int>(_snakePos.Item1 - 1, _snakePos.Item2);
                        SnakePos.Add(_snakePos);
                        break;
                }

                if (_grow != true)
                    SnakePos.RemoveAt(0);
                _grow = false;
            }
        }
    }
}