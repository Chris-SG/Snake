using SwinGameSDK;

namespace Snake
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("Snake", 800, 600);
            //SwinGame.ShowSwinGameSplashScreen();
            //GameController.StartGame();
            //Run the game loop
            do
            {
                GameController.HandleUserInput();
                GameController.DrawGame();
            } while (!SwinGame.WindowCloseRequested() && !GameController.Quitting);
        }
    }
}