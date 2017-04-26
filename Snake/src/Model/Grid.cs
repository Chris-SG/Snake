using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SwinGameSDK;

namespace MyGame.src
{
    class Grid
    {
        private Point2D _gridSize;
        private char[,] _grid;

        Grid(Point2D gridSize)
        {
            _gridSize = gridSize;
            _grid = new char[Width, Height];
        }

        public int Width
        {
            get
            {
                return Convert.ToInt32(_gridSize.X);
            }
        }

        public int Height
        {
            get
            {
                return Convert.ToInt32(_gridSize.Y);
            }
        }
        public char View(Point2D pos)
        {
            return _grid[Convert.ToInt32(pos.X), Convert.ToInt32(pos.Y)];
        }
        
    }
}
