using System.Collections.Generic;
 using System.Linq;
 using SplashKitSDK;

 public class RobotDodge
 {
 public Player _Player;
 public List<Robot> _Robots = new List<Robot>();
 private Window _GameWindow;

 public bool Quit
 {
 get
 {
 return _Player.Quit;
 }
 }

 public RobotDodge(Window gameWindow)
 {
 _GameWindow = gameWindow;
 _Player = new Player(gameWindow, this);
 }

 public void HandleInput()
 {
 _Player.HandleInput();
 _Player.StayOnWindow(_GameWindow);
 }

 public void Update()
 {
 CheckCollisions();

 foreach (var robot in _Robots)
 {
 robot.Update();
 }

 _Player.IncreaseScore();

 _Player.UpdateBullets(_Robots);

 if (SplashKit.Rnd() < 0.02)
 {
 _Robots.Add(RandomRobot());
 }
 }

 public void Draw()
 {
 _GameWindow.Clear(Color.White);

 foreach (var robot in _Robots)
 {
 robot.Draw();
 }

 _Player.Draw(_GameWindow);
 _Player.DrawBullets();
 _GameWindow.Refresh();
 }

 private Robot RandomRobot()
 {
 return new Robot(_GameWindow, _Player);
 }

 private void CheckCollisions()
 {
 List<Robot> robotsToRemove = new List<Robot>();

 foreach (var robot in _Robots)
 {
 if (_Player.CollidedWith(robot))
 {
 _Player.DecreaseLives();
 robotsToRemove.Add(robot);
 }

 if (robot.IsOffscreen(_GameWindow))
 {
robotsToRemove.Add(robot);
 }
}

 foreach (var robotToRemove in robotsToRemove)
 {
_Robots.Remove(robotToRemove);
 }
 }
 }

