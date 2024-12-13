using System;
using SplashKitSDK;

namespace ManyRobot
{
    public class Program
    {
        public static void Main()
        {
            Window gameWindow = new Window("Robot Dodge Game", 800, 600);
            RobotDodge game = new RobotDodge(gameWindow);

            // Main game loop
            while (!game.Quit && !gameWindow.CloseRequested)
            {
                // Clear the screen to white at the beginning of each frame
                gameWindow.Clear(Color.White);

                // Handle player input
                game.HandleInput();

                // Update the game state
                game.Update();

                // Draw all game elements on the screen
                game.Draw();

                // Check if the left mouse button is clicked to shoot a bullet
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    game.Player.ShootBullet();
                }

                // Refresh the game window at a rate of 60 frames per second
                gameWindow.Refresh(60);

                // Process all pending events
                SplashKit.ProcessEvents();
            }

            // Close the game window when the game loop ends
            gameWindow.Close();
        }
    }
}
