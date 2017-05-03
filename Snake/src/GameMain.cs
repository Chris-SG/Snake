using System;
using System.Linq;
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

            //Run the game loop
            do
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0, 0);

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            } while (!SwinGame.WindowCloseRequested());
        }
        
    }
}