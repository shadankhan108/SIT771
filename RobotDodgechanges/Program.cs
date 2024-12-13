using SplashKitSDK;
#nullable disable

 namespace _2_3C
 {
 public class Program
 {
 public static void Main()
 {
 try
 {
 Window gameWindow = new Window("Robot Dodge Game", 800, 600);
 RobotDodge robotDodge = new RobotDodge(gameWindow);

 while (!robotDodge.Quit && !gameWindow.CloseRequested)
 {
 gameWindow.Clear(Color.White);
 robotDodge.Draw();
 robotDodge.HandleInput();
 robotDodge.Update();
 if (SplashKit.MouseClicked(MouseButton.LeftButton))
 {
 robotDodge._Player.ShootBullet();
 }
 gameWindow.Refresh();

 SplashKit.ProcessEvents();
 SplashKit.Delay(16);
 }

 gameWindow.Close();
 }
 catch (Exception ex)
 {
 Console.WriteLine($"An exception occurred: {ex}");
 }
 }
 }
 }

