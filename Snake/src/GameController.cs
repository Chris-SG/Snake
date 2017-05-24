﻿using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace Snake
{
    public static class GameController
    {
		private const int OFFSET = 50;
        private const int F_SZ_L = 72;
        private const int F_SZ_M = 30;
        private const int F_SZ_N = 20;
        private static readonly Color BG_CLR = Color.DarkOliveGreen;
        private static readonly Color FONT_CLR = Color.Black;
        private static readonly Color S_CLR = Color.Black;
        private static readonly Font T_FONT = SwinGame.LoadFont("Fipps.otf", F_SZ_L);
        private static readonly Font M_FONT = SwinGame.LoadFont("Minecraft.ttf", F_SZ_M);
        private static readonly Font N_FONT = SwinGame.LoadFont("Minecraft.ttf", F_SZ_N);
        private static int _winX, _winY;
		private static int _snake_offset_x, _snake_offset_y, _snake_part_length;
        private static Rectangle _optionbutton, _gridplusbutton, _gridminusbutton, _speedplusbutton, _speedminusbutton, _menubutton;
        private static Stack<GameState> _state;

        private static Grid _grid;
		private static bool _quitting = false;

		static GameController()
        {
			_winX = SwinGame.WindowWidth(SwinGame.WindowAtIndex(0));
			_winY = SwinGame.WindowHeight(SwinGame.WindowAtIndex(0));
			if (_winX > _winY)
			{
				_snake_offset_y = OFFSET;
				_snake_offset_x = ((_winX - _winY) / 2) + OFFSET;
			}
			else
			{
				_snake_offset_x = OFFSET;
				_snake_offset_y = ((_winY - _winX) / 2) + OFFSET;
			}
			_state = new Stack<GameState>();
			_state.Push(GameState.MainMenu);
            InitializeButtons();

        }

        public static void StartGame()
		{
			_state.Push(GameState.InGame);
			var lGrid = new Tuple<int, int>(12, 12);
			_snake_part_length = ((_winX - 2*_snake_offset_x) / lGrid.Item1);
			_grid = new Grid(lGrid);
			_grid.CommenceGame(15);
        }

        public static void HandleUserInput()
        {
            SwinGame.ProcessEvents();
			switch (_state.Peek())
			{
				case GameState.MainMenu:
                    if (SwinGame.KeyDown(KeyCode.SpaceKey)) 
					    StartGame(); // if button is clicked then commence
                    if (ButtonClicked(_optionbutton))
                        _state.Push(GameState.Options);
					break;

                case GameState.Options:
                    if (ButtonClicked(_menubutton))
                        _state.Push(GameState.MainMenu);
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
						_state.Push(GameState.GameOver);
					}
					break;
				case GameState.GameOver:
                    if (SwinGame.MouseClicked(MouseButton.LeftButton))
					    _state.Push(GameState.MainMenu);
				    break;
				case GameState.Quitting:
					_quitting = true;
					break;
			}


        }

        private static void DrawMainMenu()
        {
            SwinGame.ClearScreen(BG_CLR);
            SwinGame.DrawText("SNAKE", FONT_CLR, T_FONT, _winX/4, _winY/5);
            DrawOptionButton();
            SwinGame.DrawText("Press SPACE key to start the game!", FONT_CLR, M_FONT, _winX/7, _winY/2 + 20);
        }

        private static void InitializeButtons()
        {
            //Option button on the main menu
            _optionbutton.X = _winX / 3 + 10;
            _optionbutton.Y = _winY - (_winY / 9);
            _optionbutton.Width = 200;
            _optionbutton.Height = _optionbutton.X / 4;

            //Grid size plus button
            _gridplusbutton.X = _winX/2 + 250;
            _gridplusbutton.Y = _winY/3 + 100;
            _gridplusbutton.Width = 50;
            _gridplusbutton.Height = 50;

            //Grid size minus button
            _gridminusbutton.X = _winX/2 + 50;
            _gridminusbutton.Y = _winY / 3 + 100;
            _gridminusbutton.Width = 50;
            _gridminusbutton.Height = 50;

            //Speed plus button
            _speedplusbutton.X = _winX / 2 + 250;
            _speedplusbutton.Y = _winY / 3 + 250;
            _speedplusbutton.Width = 50;
            _speedplusbutton.Height = 50;

            //Speed minus button
            _speedminusbutton.X = _winX / 2 + 50;
            _speedminusbutton.Y = _winY / 3 + 250;
            _speedminusbutton.Width = 50;
            _speedminusbutton.Height = 50;

            //Menu button
            _menubutton.X = _winX / 2 - 100;
            _menubutton.Y = _winY - 50;
            _menubutton.Width = 200;
            _menubutton.Height = 50;
        }

        private static void DrawOptionButton()
        {           
            SwinGame.FillRectangle(Color.Black, _optionbutton);
            SwinGame.DrawText("OPTIONS", Color.DarkGreen, M_FONT, _optionbutton.X +10, _optionbutton.Y + 10);
        }

        private static void DrawSnake(SnakeObject s)
        {
            foreach (var parts in s.SnakePos)
            {
                SwinGame.FillRectangle(S_CLR, parts.Item1 * _snake_part_length + _snake_offset_x, parts.Item2* _snake_part_length + _snake_offset_y, _snake_part_length, _snake_part_length);
                SwinGame.DrawRectangle(BG_CLR, parts.Item1 * _snake_part_length + _snake_offset_x, parts.Item2 * _snake_part_length + _snake_offset_y, _snake_part_length, _snake_part_length);
            }
			foreach(var itm in _grid.Items)
			{
				SwinGame.FillRectangle(S_CLR, itm.X * _snake_part_length + _snake_offset_x, itm.Y * _snake_part_length + _snake_offset_y, _snake_part_length, _snake_part_length);
			}

			SwinGame.FillRectangle(Color.Black, _snake_offset_x - _snake_part_length, _snake_offset_y - _snake_part_length, (_grid.Width+2) * _snake_part_length, _snake_part_length);
			SwinGame.FillRectangle(Color.Black, _snake_offset_x - _snake_part_length, _snake_offset_y - _snake_part_length, _snake_part_length, (_grid.Height+2) * _snake_part_length);
			SwinGame.FillRectangle(Color.Black, _snake_offset_x - _snake_part_length, _grid.Height * _snake_part_length + _snake_offset_y, (_grid.Width+2) * _snake_part_length, _snake_part_length);
			SwinGame.FillRectangle(Color.Black, _grid.Width * _snake_part_length + _snake_offset_x, _snake_offset_y - _snake_part_length, _snake_part_length, (_grid.Height+2) * _snake_part_length);

			SwinGame.DrawText(_grid.Score_String, Color.Black, (float)10, (float)(_winY - 50));
		}

        public static void DrawGameOver()
        {
            SwinGame.ClearScreen(BG_CLR);
            SwinGame.DrawText("GAME OVER", FONT_CLR, T_FONT, _winX/8, _winY/5);
            SwinGame.DrawText("Click anywhere to return to the main menu", FONT_CLR, N_FONT, _winX/5 + 50, _winY - 100);
        }

        public static void DrawOptionsMenu()
        {
            SwinGame.ClearScreen(BG_CLR);
            SwinGame.DrawText("OPTIONS", FONT_CLR, T_FONT, _winX / 5, _winY / 6);

            SwinGame.FillRectangle(Color.White,_gridplusbutton);
            SwinGame.DrawText("+", FONT_CLR, M_FONT, _gridplusbutton.X + 15, _gridplusbutton.Y + 15);
            SwinGame.FillRectangle(Color.White, _gridminusbutton);
            SwinGame.DrawText("-", FONT_CLR, M_FONT, _gridminusbutton.X + 15, _gridminusbutton.Y + 15);
            SwinGame.FillRectangle(Color.White, _speedplusbutton);
            SwinGame.DrawText("+", FONT_CLR, M_FONT, _speedplusbutton.X + 15, _speedplusbutton.Y + 15);
            SwinGame.FillRectangle(Color.White, _speedminusbutton);
            SwinGame.DrawText("-", FONT_CLR, M_FONT, _speedminusbutton.X + 15, _speedminusbutton.Y + 15);

            SwinGame.DrawText("GRID SIZE", FONT_CLR, M_FONT, _winX / 5, _winY / 3 + 100);
            SwinGame.DrawText("SPEED", FONT_CLR, M_FONT, _winX / 5, _winY / 3 + 250);

            SwinGame.FillRectangle(Color.Black, _menubutton);
            SwinGame.DrawText("Menu", Color.White, M_FONT, _menubutton.X + 10, _menubutton.Y + 10);
        }

        public static void DrawGame()
        {
            SwinGame.ClearScreen(BG_CLR);

			switch(_state.Peek())
			{
				case GameState.MainMenu:
                    DrawMainMenu();
					break;

                case GameState.Options:
                    DrawOptionsMenu();
                    break;

				case GameState.InGame:
					DrawSnake(_grid.SnakeObj);
					break;
				case GameState.GameOver:
                    DrawGameOver();
					break;
				case GameState.Quitting:
					break;

			}


            SwinGame.DrawFramerate(0, 0);
            SwinGame.RefreshScreen(60);
        }

        
        private static bool ButtonClicked(Rectangle button)
        {
            bool _wasClicked = false;
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                if (SwinGame.PointInRect(SwinGame.MousePosition(),button))
                {
                    _wasClicked = true;
                }
                else
                {
                    _wasClicked = false;
                }
            }
            else
            {
                _wasClicked = false;
            }
            return _wasClicked;
        }

        public static bool Quitting
		{
			get { return _quitting; }
		}
    }
}