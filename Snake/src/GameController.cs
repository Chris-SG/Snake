using System;
using SwinGameSDK;

namespace Snake
{
    public static class GameController
    {
        private static readonly int SNAKE_PART_LENGTH = 25;
        private static GameState _state;

        private static readonly Grid _grid;

        static GameController()
        {
            var lGrid = new Tuple<int, int>(12, 12);
            _grid = new Grid(lGrid);
        }

        public static void StartGame()
        {
            _grid.CommenceGame();
        }

        public static void HandleUserInput()
        {
            SwinGame.ProcessEvents();
            if (SwinGame.KeyDown(KeyCode.DownKey))
            {
                if (_grid.SnakeObj.Direction != SnakeDirection.Up)
                    _grid.SnakeObj.Direction = SnakeDirection.Down;
            }
            if (SwinGame.KeyDown(KeyCode.RightKey))
            {
                if (_grid.SnakeObj.Direction != SnakeDirection.Left)
                    _grid.SnakeObj.Direction = SnakeDirection.Right;
            }
            if (SwinGame.KeyTyped(KeyCode.LeftKey))
            {
                if (_grid.SnakeObj.Direction != SnakeDirection.Right)
                    _grid.SnakeObj.Direction = SnakeDirection.Left;
            }
            if (SwinGame.KeyTyped(KeyCode.UpKey))
            {
                if (_grid.SnakeObj.Direction != SnakeDirection.Down)
                    _grid.SnakeObj.Direction = SnakeDirection.Up;
            }
            _grid.SnakeObj.Movement();
        }

        public static void DrawSnake(SnakeObject s)
        {
            foreach (var parts in s.SnakePos)
            {
                SwinGame.FillRectangle(Color.Coral, s.X,  s.Y,
                                                    SNAKE_PART_LENGTH, SNAKE_PART_LENGTH);
            }
        }

        public static void DrawGame()
        {
            SwinGame.ClearScreen(Color.White);

            DrawSnake(_grid.SnakeObj);

            SwinGame.DrawFramerate(0, 0);

            SwinGame.RefreshScreen(60);
        }
    }
}