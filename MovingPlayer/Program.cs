using System;
using SplashKitSDK;

namespace MovePlayer
{
    public class Program
    {
        public static void Main()
        {
        Window gameWindow = new Window("Moving Player Window", 800,600);
        Player player = new Player(gameWindow);

        while (!player.Quit && !gameWindow.CloseRequested)
        {
            gameWindow.Clear(Color.White);

            player.HandleInput();
            player.StayOnWindow(gameWindow);
            player.Draw();

            gameWindow.Refresh(60);
            SplashKit.ProcessEvents();
        }
        }
    }
}
