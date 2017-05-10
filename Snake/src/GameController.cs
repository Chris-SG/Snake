using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace Snake
{
    public static class GameController
    {
        private static GameState _state;

		private static SnakeObject _snake;

		static GameController()
		{
			_snake = new SnakeObject();
		}

		public static void StartGame()
		{
			_snake.Spawn();
		}

		public static void HandleUserInput()
		{
			SwinGame.ProcessEvents();
		}

		public static void DrawGame()
		{
			SwinGame.ClearScreen(Color.White);



			SwinGame.DrawFramerate(0, 0);

			SwinGame.RefreshScreen(60);
		}
    }
}