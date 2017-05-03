using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SwinGameSDK;

namespace Snake
{
    /// <summary>
    /// A grid is the map in which the Snake game is played.
    /// It can include a Snake and food.
    /// </summary>
    public class Grid
    {
        private Point2D _gridSize;
        private char[,] _grid;

        /// <summary>
        /// The constructor can use any given grid size.
        /// </summary>
        /// <param name="gridSize">The size of the grid.</param>
        Grid(Point2D gridSize)
        {
            _gridSize = gridSize;
            _grid = new char[Width, Height];

            for(int i = 0; i < Width; i++)
            {
                for(int j = 0; j < Height; j++)
                {
                    _grid[i, j] = (char)0;
                }
            }
        }

        /// <summary>
        /// Width of the grid.
        /// </summary>
        public int Width
        {
            get
            {
                return Convert.ToInt32(_gridSize.X);
            }
        }
        
        /// <summary>
        /// Height of the grid.
        /// </summary>
        public int Height
        {
            get
            {
                return Convert.ToInt32(_gridSize.Y);
            }
        }

        /// <summary>
        /// View a particular location on the grid.
        /// </summary>
        /// <param name="pos">Position to investigate.</param>
        /// <returns>Value from given position.</returns>
        public char View(Point2D pos)
        {
            return _grid[Convert.ToInt32(pos.X), Convert.ToInt32(pos.Y)];
        }
        
    }
}
