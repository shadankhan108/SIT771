using System;
using SplashKitSDK;

namespace RobotDodge
{
    public class Program
    {
        static void Main()
        {
            
            Window gameWindow = new Window("Robot Dodge", 800, 600);

            
            Player player = new Player(gameWindow);

            
                gameWindow.Clear(Color.White);

                
                player.Draw();

            
                gameWindow.Refresh(60);
                
            while (!gameWindow.CloseRequested)
            {
                SplashKit.ProcessEvents();
            }
        }
    }
}

