
using SplashKitSDK;
#nullable disable

namespace RobotDodge2
{
public class Program
{
public static void Main()
{
Window gameWindow = new Window("Robot Dodge Game", 800, 600);
RobotDodge robotDodge = new RobotDodge(gameWindow);

while (!robotDodge.Quit && !gameWindow.CloseRequested)
{
gameWindow.Clear(Color.White);
robotDodge.HandleInput();
robotDodge.Draw();
robotDodge.Update();
gameWindow.Refresh();

SplashKit.ProcessEvents();
SplashKit.Delay(16);
}

gameWindow.Close();
}
}
}
