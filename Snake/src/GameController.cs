using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace Snake
{
    public static class GameController
    {
        private static readonly int SNAKE_PART_LENGTH = 25;
		private static int SNAKE_DRAWING_OFFSET;
        private static Stack<GameState> _state;

        private static Grid _grid;

        static GameController()
        {
			SNAKE_DRAWING_OFFSET = 50;
			_state = new Stack<GameState>();
			_state.Push(GameState.MainMenu);
        }

        public static void StartGame()
		{
			_state.Push(GameState.InGame);
			var lGrid = new Tuple<int, int>(12, 12);
			_grid = new Grid(lGrid);
			_grid.CommenceGame(15);
        }

        public static void HandleUserInput()
        {
            SwinGame.ProcessEvents();
			switch (_state.Peek())
			{
				case GameState.MainMenu:
					StartGame();
					break;
				case GameState.InGame:
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

					if (_grid.CheckCollisions())
					{
						_state.Pop();
					}
					break;
				case GameState.GameOver:
					break;
				case GameState.Quitting:
					break;
			}


        }

        public static void DrawSnake(SnakeObject s)
        {
            foreach (var parts in s.SnakePos)
            {
                SwinGame.FillRectangle(Color.Coral, parts.Item1 * SNAKE_PART_LENGTH + SNAKE_DRAWING_OFFSET, parts.Item2* SNAKE_PART_LENGTH + SNAKE_DRAWING_OFFSET, SNAKE_PART_LENGTH, SNAKE_PART_LENGTH);
                SwinGame.DrawRectangle(Color.BlanchedAlmond, parts.Item1 * SNAKE_PART_LENGTH + SNAKE_DRAWING_OFFSET, parts.Item2 * SNAKE_PART_LENGTH + SNAKE_DRAWING_OFFSET, SNAKE_PART_LENGTH, SNAKE_PART_LENGTH);
            }
			foreach(var itm in _grid.Items)
			{
				SwinGame.FillRectangle(Color.GreenYellow, itm.X * SNAKE_PART_LENGTH + SNAKE_DRAWING_OFFSET, itm.Y * SNAKE_PART_LENGTH + SNAKE_DRAWING_OFFSET, SNAKE_PART_LENGTH, SNAKE_PART_LENGTH);
			}

			SwinGame.FillRectangle(Color.Black, SNAKE_DRAWING_OFFSET-SNAKE_PART_LENGTH, SNAKE_DRAWING_OFFSET-SNAKE_PART_LENGTH, (_grid.Width+2) * SNAKE_PART_LENGTH, SNAKE_PART_LENGTH);
			SwinGame.FillRectangle(Color.Black, SNAKE_DRAWING_OFFSET-SNAKE_PART_LENGTH, SNAKE_DRAWING_OFFSET-SNAKE_PART_LENGTH, SNAKE_PART_LENGTH, (_grid.Height+2) * SNAKE_PART_LENGTH);
			SwinGame.FillRectangle(Color.Black, SNAKE_DRAWING_OFFSET-SNAKE_PART_LENGTH, _grid.Height * SNAKE_PART_LENGTH + SNAKE_DRAWING_OFFSET, (_grid.Width+2) * SNAKE_PART_LENGTH, SNAKE_PART_LENGTH);
			SwinGame.FillRectangle(Color.Black, _grid.Width * SNAKE_PART_LENGTH + SNAKE_DRAWING_OFFSET, SNAKE_DRAWING_OFFSET- SNAKE_PART_LENGTH, SNAKE_PART_LENGTH, (_grid.Height+2) * SNAKE_PART_LENGTH);
		}

        public static void DrawGame()
        {
            SwinGame.ClearScreen(Color.White);

			switch(_state.Peek())
			{
				case GameState.MainMenu:
					break;
				case GameState.InGame:
					DrawSnake(_grid.SnakeObj);
					break;
				case GameState.GameOver:
					break;
				case GameState.Quitting:
					break;

			}


            SwinGame.DrawFramerate(0, 0);
            SwinGame.RefreshScreen(60);
        }
    }
}