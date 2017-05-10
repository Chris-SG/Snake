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

		private static Grid _grid;

		static GameController()
		{
			Point2D lPt = new Point2D();
			lPt.X = 12;
			lPt.Y = 12;
			_grid = new Grid(lPt);
		}

		public static void StartGame()
		{
			_grid.CommenceGame();
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